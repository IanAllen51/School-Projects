using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoMid2
{
    public class SequenceBuilder
    {
        public List<Shape> shapeList;
        public string sequence;
        char[] acceptableSymbol = { 'c', 's', 'r', ' ' };
        public SequenceBuilder(string seq)
        {
            this.sequence = seq;
        }

        public string GenerateSequence() //string done. need to generate list<shapes>
        {
            string newSequence = string.Empty;
            do
            {
                Console.Write("Please enter a sequence of shapes(s,r,c) separated by a space: ");
                string input = Console.ReadLine();
                int index = 0;
                foreach (char symbol in input)
                {
                    //check for proper shapes
                    if (!acceptableSymbol.Contains(symbol))
                    {
                        Console.WriteLine(symbol + " is not a recognizable shape. ReEnter sequence.");
                        break;
                    }
                    //check for proper spacing
                    if (index % 2 != 0 && symbol != ' ')
                    {
                        Console.WriteLine("Error in spacing. ReEnter sequence");
                        break;
                    }
                    
                    index++;
                }
                if (index == input.Length)
                {
                    newSequence = input + " "; //ADDED Space
                }
            } while (newSequence == string.Empty);
           
            return newSequence;
        }

        public string AddSequence(string originalSeq) //originalSeq will be demo.sequence in Program main.
        {
            string addedSeq = GenerateSequence();
            string newSequence = originalSeq + addedSeq + " "; //ADDED space
            return newSequence;
        }

        public string DeleteSequence(string originalSeq, List<Shape>list)
        {
            string reducedSequence = string.Empty;
            string findText = GenerateSequence();
            if(originalSeq.Contains(findText))
            {
                int foundIndex = originalSeq.IndexOf(findText);
                reducedSequence = originalSeq.Remove(foundIndex, findText.Length);
                list.RemoveRange((foundIndex / 2), ((findText.Length) / 2));
                Update((foundIndex / 2));
            }
            else
            {
                Console.WriteLine("Sequence is not found.");
                Console.WriteLine();
            }
            return reducedSequence;
        }

        public string AlterSequence(string originalSeq)
        {
            string changedSeq = string.Empty;
            string findText = GenerateSequence();
            if(originalSeq.Contains(findText))
            {
                Console.WriteLine("What would you like to replace " + findText + " with?");
                string changeInput = GenerateSequence();
                changedSeq = originalSeq.Replace(findText, changeInput);
                AlterShape(findText, changeInput, originalSeq);
            }
            else
            {
                Console.WriteLine("Sequence is not found.");
                Console.WriteLine();
            }
            return changedSeq;
        }

        public Shape BuildShape(int index, char symbol)
        {
            Shape shape;
            if(symbol == 's')
            {
                shape = new Square(index);
            }
            else if(symbol == 'r')
            {
                shape = new Rectangle(index);
            }
            else
            {
                shape = new Circle(index);
            }
            return shape;
        }

        public List<Shape> GenerateShapeList(string sequence)
        {
            List<Shape> genList = new List<Shape>();
            int index = 1;
            foreach(char symbol in sequence)
            {
                if(symbol != ' ')
                {
                    genList.Add(BuildShape(index,symbol));
                    index++;
                }
            }
            return genList;
        }

        public void AddShape(string seq, List<Shape>list)
        {
            for (int index = (list.Count * 2); index < seq.Length; index++) //<=
            {
                if(seq[index] != ' ')
                {
                    list.Add(BuildShape(list.Count + 1, seq[index]));
                }
            }
        }

        public void ListShapes(List<Shape>list)
        {
            foreach(Shape shape in list)
            {
                shape.DisplayInfo();
            }
        }

        public double TotalArea(List<Shape> list)
        {
            double total = 0.0;
            foreach (Shape shape in list)
            {
                total += shape.GetArea();
            }
            return total;
        }

        public void Update(int index)
        {
            for (int i = index; i < shapeList.Count; i++)
            {
                shapeList[index].Index = index + 1;
            }
        }

        public void ChangeDefault(int index, int size)
        {
            for (int i = index; i < shapeList.Count; i++)
            {
                shapeList[i].BaseSize = size;
            }
        }

        public void AlterShape(string find, string alter, string original)
        {
            int foundIndex = original.IndexOf(find);
            shapeList.RemoveRange((foundIndex / 2), (find.Length / 2));
            int loopIndex = foundIndex / 2;
            for (int i = 0; i < alter.Length; i++)
            {
                if(alter[i] != ' ')
                {
                    shapeList.Insert(loopIndex,BuildShape(loopIndex + 1, alter[i]));
                    loopIndex++;
                }
            }
            Update(loopIndex);
        }

        public List<Shape> TransformList(Func<Shape,bool> filter )
        {
            List<Shape> filterList = new List<Shape>();
            foreach(Shape shape in shapeList)
            {
                if(filter(shape))
                {
                    filterList.Add(shape);
                }
                
            }
            return filterList;
        }
    }
}
