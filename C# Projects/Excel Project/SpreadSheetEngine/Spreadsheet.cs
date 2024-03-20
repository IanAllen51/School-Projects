// <copyright file="Spreadsheet.cs" company="Ian Allen, SID: 011740734">
// Copyright (c) Ian Allen, SID: 011740734. All rights reserved.
// </copyright>

namespace SpreadSheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Eventing.Reader;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using ExpressionTreeEngine;

    /// <summary>
    /// Spreadsheet class that will utilize the SpreadsheetCell class to construct a 2D array of cells.
    /// </summary>
    public class Spreadsheet
    {
        /// <summary>
        /// 2D array of cells that will form the programatic equivalent of the spreadsheet in form1.
        /// </summary>
        private readonly Cell[,] cellArray;

        /// <summary>
        /// ExpressionTree that will evaluate expressions added to cells.
        /// </summary>
        private ExpressionTree expTree = new ExpressionTree();

        /// <summary>
        /// total number of rows within the spreadsheet.
        /// </summary>
        private int rowCount;

        /// <summary>
        /// total number of columns within the spreadsheet.
        /// </summary>
        private int columnCount;

        /// <summary>
        /// Stack of UndoRedoCollection variables that will represent all changes made to the form1. To be popped off to
        /// represent the undo method.
        /// </summary>
        private Stack<UndoRedoCollection> undo;

        /// <summary>
        /// Stack of UndoRedoCollection variables that will represent all Undo actions. Will be popped off whith each redo call.
        /// </summary>
        private Stack<UndoRedoCollection> redo;

        /// <summary>
        /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
        /// Spreadsheet constructor will call property changed event every time the spreasheet is reloaded/updated.
        /// </summary>
        /// <param name="rowNum">Row index for spreadsheet. Maximum rows.</param>
        /// <param name="colNum">Column index for spreadsheet. Maximum columns.</param>
        public Spreadsheet(int rowNum, int colNum)
        {
            this.rowCount = rowNum;
            this.columnCount = colNum;
            this.cellArray = new SpreadsheetCell[rowNum, colNum];
            this.undo = new Stack<UndoRedoCollection>();
            this.redo = new Stack<UndoRedoCollection>();
            for (int row = 0; row < rowNum; row++)
            {
                for (int col = 0; col < colNum; col++)
                {
                    this.cellArray[row, col] = new SpreadsheetCell(row, col);
                    this.cellArray[row, col].PropertyChanged += this.PropertyEventChangeHanlder; // sends change notice to Cell and Spreadsheet cell class
                }
            }
        }

        /// <summary>
        /// Event handler that will keep track of any updates to the spreadsheet via the PropertyEventChangeHanlder method.
        /// </summary>
        public event EventHandler CellPropertyChanged = (sender, e) => { }; // (sender, e) => replaces delegate {}

        /// <summary>
        /// Gets the column count of the spreadsheet instance.
        /// </summary>
        public int ColumnCount
        {
            get { return this.columnCount; }
        }

        /// <summary>
        /// Gets the rowcount of the spreadsheet instance.
        /// </summary>
        public int RowCount
        {
            get { return this.rowCount; }
        }

        /// <summary>
        /// Helper method to push undoredocollection variable onto undo stack.
        /// </summary>
        /// <param name="action">UndoRedoCollection variable generated in events.</param>
        public void AddUndo(UndoRedoCollection action)
        {
            this.undo.Push(action);
        }

        /// <summary>
        /// Helper method to pop the top UndoRedoCollection Variable from the undo stack.
        /// </summary>
        /// <returns>the top undoredocollection variable on undo stack.</returns>
        public UndoRedoCollection RemoveUndo()
        {
            return this.undo.Pop();
        }

        /// <summary>
        /// Helper method to get the top variable on the undo stack.
        /// </summary>
        /// <returns>UndoRedoCollection variable on the top of undo stack.</returns>
        public UndoRedoCollection PeekUndo()
        {
            return this.undo.Peek();
        }

        /// <summary>
        /// Helper method to push undoredocollection variable onto the top of the redo stack.
        /// </summary>
        /// <param name="action">undoredocollection variable that was popped from the top of the undo stack.</param>
        public void AddRedo(UndoRedoCollection action)
        {
            this.redo.Push(action);
        }

        /// <summary>
        /// Helper method to pop undoredocollection variable from the top of the redo stack.
        /// </summary>
        /// <returns>undoredocollection variable at the top of the redo stack.</returns>
        public UndoRedoCollection RemoveRedo()
        {
            return this.redo.Pop();
        }

        /// <summary>
        /// Helper method to access the top variable on the redo stack.
        /// </summary>
        /// <returns>undoredocollection variable at the top of the redo stack.</returns>
        public UndoRedoCollection PeekRedo()
        {
            return this.redo.Peek();
        }

        /// <summary>
        /// Helper method to check if undo stack is empty.
        /// </summary>
        /// <returns>bool of empty status.</returns>
        public bool IsUndoEmpty()
        {
            return this.undo.Count == 0;
        }

        /// <summary>
        /// Helper method to checki if redo stack is empty.
        /// </summary>
        /// <returns>bool of empty status.</returns>
        public bool IsRedoEmpty()
        {
            return this.redo.Count == 0;
        }

        /// <summary>
        /// GetCellByName allows for reading a string to generate the row and column based on string representation.
        /// </summary>
        /// <param name="name">string that will be passed in as a substring from the propertyEventChangeHandler.</param>
        /// <returns>returns cell located at the parsed loacation.</returns>
        public Cell GetCellByName(string name)
        {
            char columnName = name[0];
            int col = columnName - 'A'; // indexing by subtracting A. Ex. A-A would be 0, B-A would be 1...

            int row = int.Parse(name.Substring(1)) - 1;
            return this.GetCell(row, col);
        }

        /// <summary>
        /// Returns the cell located in the cellArray at the given row and column value.
        /// </summary>
        /// <param name="row">value representing the row index.</param>
        /// <param name="col">value representing the column index.</param>
        /// <returns>Returns the cell reference at the designated row and column value.</returns>
        public Cell GetCell(int row, int col)
        {
            return this.cellArray[row, col];
        }

        /// <summary>
        /// The purpose of this function is to unsubscribe the previous variable before update cell text.
        /// </summary>
        /// <param name="row">value representing the row index.</param>
        /// <param name="col">value representing the column index.</param>
        public void UnsubscribeReferenceVariable(int row, int col)
        {
            Cell targetCell = this.GetCell(row, col);
            if (targetCell.Text != null && targetCell.Text[0] == '=')
            {
                try
                {
                    ExpressionTree expressionTree = new ExpressionTree();
                    expressionTree.SetExpression(targetCell.Text.Substring(1));
                    List<string> variableList = expressionTree.ReturnVariablesNeeded();
                    foreach (string variable in variableList)
                    {
                        this.GetCellByName(variable).PropertyChanged -= targetCell.PropertyEventChangeHanlder;
                    }
                }
                catch (ArithmeticException)
                {
                }
            }
        }

        /// <summary>
        /// Helper method to clear undo stack.
        /// </summary>
        public void ClearUndoStack()
        {
            this.undo.Clear();
        }

        /// <summary>
        /// Helper method to clear redo stack.
        /// </summary>
        public void ClearRedoStack()
        {
            this.redo.Clear();
        }

        /// <summary>
        /// SaveXmlFile will take a xml stream and will generate a new xml file that will use Spreadsheet as root and will have cell children.Each cell will
        /// have elements cellname, bgcolor, and text. These will represent the cellArray position, background color and text value respectively. The method
        /// will iterate through the spreadsheet and perfrom XmlWriter on any cells altered from default state.
        /// </summary>
        /// <param name="filesource">xml file to be written to.</param>
        public void SaveXmlFile(string filesource)
        {
            XmlWriter writer = XmlWriter.Create(filesource);
            writer.WriteStartElement("SpreadSheet");
            for (int row = 0; row < this.rowCount; row++)
            {
                for (int col = 0; col < this.columnCount; col++)
                {
                    // check if cell has been altered.
                    if (this.cellArray[row, col].Text != null || this.cellArray[row, col].BGColor != 0xFFFFFFFF)
                    {
                        writer.WriteStartElement("Cell");
                        int temp = col + 65;
                        string cellName = ((char)temp).ToString() + (row + 1).ToString();
                        writer.WriteElementString("CellName", cellName);
                        writer.WriteElementString("bgcolor", this.cellArray[row, col].BGColor.ToString("X")); // writes uint val as hexadecimal string
                        writer.WriteElementString("text", this.cellArray[row, col].Text);
                        writer.WriteEndElement();
                    }
                }
            }

            writer.WriteEndElement();
            writer.Flush();

            // ADDED
            writer.Close();
        }

        /// <summary>
        /// LoadXmlFile will take the xml stream passed and populate the Spreadsheet with cell data. Utilizes a switch statement to verify what element of the xml
        /// file is being read, and what property of the cell to change with each iteration of the while loop.
        /// </summary>
        /// <param name="filesource">xml file passed.</param>
        public void LoadXmlFile(string filesource)
        {
            XmlReader reader = XmlReader.Create(filesource);
            int rowNum = 0;
            int colNum = 0;
            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    switch (reader.Name.ToString())
                    {
                        case "CellName":
                            string cellNameString = reader.ReadString();
                            char colChar = cellNameString[0];
                            colNum = colChar - 'A';
                            rowNum = int.Parse(cellNameString.Substring(1)) - 1;
                            break;
                        case "bgcolor":
                            this.GetCell(rowNum, colNum).BGColor = uint.Parse(reader.ReadString(), System.Globalization.NumberStyles.HexNumber); // converts the hex string to a uint and store in BGColor.
                            break;
                        case "text":
                            // ADDED
                            if (reader.IsEmptyElement)
                            {
                                this.GetCell(rowNum, colNum).Text = null; // set null if empty
                            }
                            else
                            {
                                this.GetCell(rowNum, colNum).Text = reader.ReadString(); // set text equal to the value in element.
                            }

                            break;
                        default:
                            break;
                    }
                }
            }

            // ADDED
            reader.Close();
        }

        /// <summary>
        /// ClearSpreadSheet is a method for emptying the current spreadsheet cell information. Essentially a new spreadsheet will be linked to the datagridview.
        /// </summary>
        /// <param name="row">number of rows in a spreadsheet. passed as int val.</param>
        /// <param name="col">number of columns in a spreadsheet. passed as int val.</param>
        public void ClearSpreadSheet(int row, int col)
        {
            for (int rowindex = 0; rowindex < row; rowindex++)
            {
                for (int colindex = 0; colindex < col; colindex++)
                {
                    this.cellArray[rowindex, colindex] = new SpreadsheetCell(rowindex, colindex);
                    this.cellArray[rowindex, colindex].PropertyChanged += this.PropertyEventChangeHanlder;
                }
            }
        }

        /// <summary>
        /// Event Handler that will be called when a change is made and triggers an update. Checks the input
        /// into the spreadsheet and if starts with =, will get the reference of the Spreadsheetcell equivalent to the following string.
        /// Will fire property changed event after setting spreadsheetcell.
        /// </summary>
        /// <param name="sender">called from the Spreasheet constructor.</param>
        /// <param name="e">each spreadsheetcell created will be a different event.</param>
        private void PropertyEventChangeHanlder(object sender, EventArgs e)
        {
            SpreadsheetCell originalCell = (SpreadsheetCell)sender; // staticcast sender.
            string text = originalCell.Text;
            try
            {
                if (text != null)
                {
                    if (text[0] == '=')
                    {
                        string originalCellName = ((char)(originalCell.ColumnIndex + 65)).ToString() + (originalCell.RowIndex + 1).ToString();
                        this.CheckSelfOrCircularReference(originalCell, originalCellName, null, 0);
                        this.expTree.SetExpression(text.Substring(1)); // if expression starts with equal, substring(1) will be the remainder of expression.
                        List<string> variableList = this.expTree.ReturnVariablesNeeded(); // Load variableList with all variables within the expression.
                        foreach (string variable in variableList)
                        {
                            string temp = this.GetCellByName(variable).Value;

                            // We make the original cell to listen to the variable cell's PropertyChanged event. For example: if we have equation A2=A1+B1,
                            // we will make A2 listen to both A1.PropertyChange and B1.PropertyChage. And if any of them fire, it will call A2.PropertyEvenChangeHandler, which will trigger A2.PropertyChanged event, and catched by it's own event handler and redo the calculation.
                            this.GetCellByName(variable).PropertyChanged += originalCell.PropertyEventChangeHanlder;
                            if (double.TryParse(temp, out double doubleResult))
                            {
                                // if value of variable is a number, set the variable within the expression tree with the double value.
                                this.expTree.SetVariable(variable, doubleResult);
                            }
                            else
                            {
                                // if variable is not a number, set value equal to 0 in expression tree.
                                if (temp == "!(SelfRef)" || temp == "!(CircularRef)")
                                {
                                    if (double.TryParse(originalCell.Value, out double result))
                                    {
                                        this.expTree.SetVariable(variable, double.Parse(originalCell.Value));
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    this.expTree.SetVariable(variable, 0);
                                }
                            }
                        }

                        // Exception to check for null referencing in dataGrid. Thrown in ExpressionTree class.
                        try
                        {
                            originalCell.SetValue(this.expTree.Evaluate().ToString());
                        }
                        catch (NullReferenceException)
                        {
                            // set value to 0.
                            originalCell.SetValue("0");
                        }
                    }
                    else
                    {
                        // check for bad reference
                        if (int.TryParse(text, out int result))
                        {
                            originalCell.SetValue(text);
                        }
                        else
                        {
                            throw new ArithmeticException("!(badRef)");
                        }
                    }
                }
                else
                {
                    originalCell.SetValue(null);
                }

                this.CellPropertyChanged(this, new EventArgs());
            }
            catch (ArithmeticException exception)
            {
                originalCell.SetValue(exception.Message);
            }
        }

        /// <summary>
        /// Helper method to check if changes to cells in datagridview are self refrencing or part of a circular reference. Recursively calls
        /// itself for each variable in the expression.
        /// </summary>
        /// <param name="cell">datagrid cell that is being altered.</param>
        /// <param name="cellName">the string name of the cell being altered.</param>
        /// <param name="previousCellName">parameter for recursive call to check the former cell visited.</param>
        /// <param name="iteration">iterator counter for how many recursions have been performed for each variable in expression.</param>
        private void CheckSelfOrCircularReference(Cell cell, string cellName, string previousCellName, int iteration)
        {
            if (cell.Text == null || cell.Text[0] != '=')
            {
                return;
            }
            else if (cellName.Equals(previousCellName) && iteration > 0)
            {
                return;
            }

            // added
            else if (cell.Text.Substring(1).Equals(previousCellName) && iteration > 0)
            {
                return;
            }
            else
            {
                // Generate a new expressiontree for each sub expression input into the cell.
                ExpressionTree expressionTree = new ExpressionTree();
                expressionTree.SetExpression(cell.Text.Substring(1));
                List<string> variableList = expressionTree.ReturnVariablesNeeded();
                if (variableList.Contains(cellName))
                {
                    if (iteration == 0)
                    {
                        throw new ArithmeticException("!(SelfRef)");
                    }
                    else
                    {
                        throw new ArithmeticException("!(CircularRef)");
                    }
                }
                else
                {
                    // each variable within the expression input into the cell.
                    foreach (string variable in variableList)
                    {
                    this.CheckSelfOrCircularReference(this.GetCellByName(variable), cellName, variable, ++iteration);
                    }
                }
            }
        }
    }
}
