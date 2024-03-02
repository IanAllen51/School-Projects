using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoMid2
{
    class Program
    {
        static void Main(string[] args)
        {
            string sequence = string.Empty;
            SequenceBuilder demo = new SequenceBuilder(sequence);
            demo.sequence = demo.GenerateSequence();
            demo.shapeList = demo.GenerateShapeList(demo.sequence);
            
            //DRIVER CODE----------------------------------
            Console.WriteLine(demo.shapeList.Count());
            foreach (Shape shape in demo.shapeList)
            {
                shape.DisplayInfo();
            }
            //---------------------------------------------

            Console.WriteLine("New Sequence is: " + demo.sequence);
            Console.WriteLine();
            string commandInput = string.Empty;
 
            do
            {
                Console.WriteLine("What action would you like?");
                Console.WriteLine("  1.Change Default Size");
                Console.WriteLine("  2.List Shapes");
                Console.WriteLine("  3.View Sequence History");
                Console.WriteLine("  4.Add Sequence of Shapes");
                Console.WriteLine("  5.Alter/Delete Sequence");
                Console.WriteLine("  6.Compute Area of Sequence");
                Console.WriteLine("  7.Filter Sequence");
                Console.WriteLine("  8.Exit");
                commandInput = Console.ReadLine();
                Console.WriteLine();

                switch (commandInput)
                {
                    case ("1"):
                        Console.WriteLine("New Size");
                        Console.Write("What index would you like to update(1-" + demo.shapeList.Count + "): ");
                        string idxInput = Console.ReadLine();
                        Console.Write("What size would you like to update default to?: ");
                        string sizeInput = Console.ReadLine();
                        demo.ChangeDefault(int.Parse(idxInput) - 1, int.Parse(sizeInput));
                        Console.WriteLine();
                        break;
                    case ("2"):
                        Console.WriteLine("List Shapes");
                        demo.ListShapes(demo.shapeList);
                        Console.WriteLine();
                        break;
                    case ("3"):
                        Console.WriteLine("View History");
                        Console.WriteLine();
                        Console.WriteLine("Sequence History: " + demo.sequence);
                        Console.WriteLine();
                        break;
                    case ("4"):
                        Console.WriteLine("Add Sequence");
                        demo.sequence = demo.AddSequence(demo.sequence);
                        demo.AddShape(demo.sequence, demo.shapeList);
                        Console.WriteLine();
                        break;
                    case ("5"):
                        Console.WriteLine("Alter/Delete");
                        string altDelInput = string.Empty;
                        do
                        {
                            Console.Write("Alter or Delete?: ");
                            altDelInput = Console.ReadLine();
                            if (altDelInput == "Alter")
                            {
                                demo.sequence = demo.AlterSequence(demo.sequence);
                            }
                            else if (altDelInput == "Delete")
                            {
                                demo.sequence = demo.DeleteSequence(demo.sequence, demo.shapeList);
                            }
                            else
                            {
                                continue;
                            }

                        } while ((altDelInput != "Alter") && (altDelInput != "Delete"));
                        Console.WriteLine();
                        break;
                    case ("6"):
                        Console.WriteLine("Compute Area");
                        Console.WriteLine("Total Area: " + demo.TotalArea(demo.shapeList));
                        Console.WriteLine();
                        break;
                    case ("7"):
                        Console.WriteLine("Filter");
                        string filterInput = string.Empty;
                        Func<Shape, bool> filtFunc = null;
                        do
                        {
                            Console.WriteLine("What would you like to filter?");
                            Console.WriteLine("  1. By Shape");
                            Console.WriteLine("  2. By Size");
                            Console.WriteLine("  3. By Area");
                            filterInput = Console.ReadLine();
                            string shapeInput = string.Empty;
                            string lambdaSize = string.Empty;
                            switch (filterInput)
                            {
                                case ("1"):
                                    do
                                    {
                                        Console.WriteLine("What Shape would you like to filter? (s,r,c)");
                                        shapeInput = Console.ReadLine();
                                    } while (shapeInput != "s" && shapeInput != "r" && shapeInput != "c");
                                    filtFunc = (Shape x) => x.Symbol == char.Parse(shapeInput);
                                    break;
                                case ("2"):
                                    do //input.Any(c => char.IsDigit(c))//lambdaSize.Any(c => char.IsLetter(c))
                                    {
                                        Console.WriteLine("What Size would you like to filter?");
                                        lambdaSize = Console.ReadLine();
                                    } while (lambdaSize == string.Empty || int.Parse(lambdaSize) < 0);
                                    filtFunc = (Shape x) => x.GetSize() < int.Parse(lambdaSize);
                                    break;
                                case ("3"):
                                    Console.WriteLine("What Area would you like to filter?");
                                    string lambdaArea = Console.ReadLine();
                                    filtFunc = (Shape x) => x.GetArea() < double.Parse(lambdaArea);
                                    break;
                                default:
                                    break;
                            }

                        } while (filterInput != "1" && filterInput != "2" && filterInput != "3");
                        List<Shape> displayLambda = demo.TransformList(filtFunc);
                        foreach (Shape shape in displayLambda)
                        {
                            shape.DisplayInfo();
                        }
                        Console.WriteLine();
                        break;
                    case ("8"):
                        Console.WriteLine("GoodBye");
                        break;
                    default:
                        break;
                }
            } while (commandInput != "8");
        }
    }
}
