// <copyright file="Form1.cs" company="Ian Allen, SID: 011740734">
// Copyright (c) Ian Allen, SID: 011740734. All rights reserved.
// </copyright>

namespace HW10_HandlingCircularRefereces
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Xml;
    using SpreadSheetEngine;

    /// <summary>
    /// Form1 will contain and call all variable and methods for displaying information into the winform form1.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// demoSpreadsheet will be the variable that will hold the 2D array of spreadsheet cells.
        /// </summary>
        private readonly Spreadsheet demoSpreadSheet;

        /// <summary>
        /// changedCellList will be a list of Cells that will be used to collect all cells that are affected by any updates/selections.
        /// </summary>
        private List<Cell> changedCellsList;

        /// <summary>
        /// changedCellText will be a list of strings that will represent all of the values within each cell stored in changedCellList.
        /// </summary>
        private List<string> changedCellText;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            this.button2.Enabled = false;
            this.button2.Text = "Undo";
            this.button3.Enabled = false;
            this.button3.Text = "Redo";
            this.changedCellsList = new List<Cell>();
            this.changedCellText = new List<string>();
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.CellBeginEdit += this.DataGridView1_CellBeginEdit;
            this.dataGridView1.CellEndEdit += this.DataGridView1_CellEndEdit;
            this.dataGridView1.CellStyleChanged += this.DataGridView1_CellStyleChanged;
            this.dataGridView1.SelectionChanged += this.DataGridView1_SelectionChanged;
            char test = 'A';
            for (int i = 1; i <= 26; i++)
            {
                this.dataGridView1.Columns.Add("column", (test++).ToString());
            }

            for (int i = 1; i <= 50; i++)
            {
                this.dataGridView1.Rows.Add();
            }

            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }

            this.demoSpreadSheet = new Spreadsheet(50, 26);

            // TEST FOR HW8---------------------------------------------------------
            for (int i = 0; i < this.demoSpreadSheet.RowCount; i++)
            {
                for (int j = 0; j < this.demoSpreadSheet.ColumnCount; j++)
                {
                    this.dataGridView1[j, i].Style.BackColor = Color.FromArgb(unchecked((int)this.demoSpreadSheet.GetCell(i, j).BGColor));
                }
            }

            //------------------------------------------------------------------------
            this.demoSpreadSheet.CellPropertyChanged += this.EventHandler; // tells that event has changed
        }

        /// <summary>
        /// The event handler will update the spreadsheet in the winform with changes made in the spreadsheet and cell classes.
        /// </summary>
        /// <param name="sender">This will be called by the cellPropertyChanged event.</param>
        /// <param name="e">e will be all of the cells changed in the spreadsheet.</param>
        private void EventHandler(object sender, EventArgs e)
        {
            for (int i = 0; i < this.demoSpreadSheet.RowCount; i++)
            {
                for (int j = 0; j < this.demoSpreadSheet.ColumnCount; j++)
                {
                    this.dataGridView1[j, i].Value = this.demoSpreadSheet.GetCell(i, j).Value;

                    // ADDED FOR HW8
                    this.dataGridView1[j, i].Style.BackColor = Color.FromArgb(unchecked((int)this.demoSpreadSheet.GetCell(i, j).BGColor));
                }
            }
        }

        /// <summary>
        /// Event to indicate the changing of a cell in the form1.
        /// </summary>
        /// <param name="sender">The changing of the cell.</param>
        /// <param name="e">the cell being altered.</param>
        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            string updateValue = this.demoSpreadSheet.GetCell(e.RowIndex, e.ColumnIndex).Text;
            this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = updateValue;
            this.changedCellsList = new List<Cell>();
            this.changedCellText = new List<string>();
            this.changedCellsList.Add(this.demoSpreadSheet.GetCell(e.RowIndex, e.ColumnIndex));
            this.changedCellText.Add(this.demoSpreadSheet.GetCell(e.RowIndex, e.ColumnIndex).Text);
        }

        /// <summary>
        /// Event to indicate the ending of altering a cell in form1.
        /// </summary>
        /// <param name="sender">The event of changing the cell.</param>
        /// <param name="e">The cell that is being altered.</param>
        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.demoSpreadSheet.UnsubscribeReferenceVariable(e.RowIndex, e.ColumnIndex); // unsubscribe all event handler before we change the text.
            object dataGridViewCellContet = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            this.demoSpreadSheet.GetCell(e.RowIndex, e.ColumnIndex).Text = dataGridViewCellContet == null ? null : dataGridViewCellContet.ToString();
            this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = this.demoSpreadSheet.GetCell(e.RowIndex, e.ColumnIndex).Value;
            if (this.changedCellsList != null && this.changedCellText.Count != 0)
            {
                dataGridViewCellContet = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                string dataGridViewCellString = dataGridViewCellContet == null ? null : dataGridViewCellContet.ToString();
                if (this.changedCellText[0] != dataGridViewCellString)
                {
                    UndoRedoCollection collection = new UndoRedoCollection();
                    collection.SetOriginalCell(this.changedCellsList);
                    collection.SetAlteredData(this.changedCellText);
                    collection.SetOperationName("Text Change");
                    this.demoSpreadSheet.AddUndo(collection);
                    this.changedCellsList = new List<Cell>();
                    this.changedCellText = new List<string>();
                    if (!this.demoSpreadSheet.IsUndoEmpty() && this.demoSpreadSheet.PeekUndo() != null)
                    {
                        this.button2.Enabled = true;
                        this.button2.Text = "Undo " + this.demoSpreadSheet.PeekUndo().GetOperationName();
                    }
                }
            }
        }

        // ADDED FOR HW8 -------------------------------------------------------------------

        /// <summary>
        /// Event that will act as the end of a changing to any cells for color change button (button1). this will allow for changedCellList and changedCellText
        /// to be used to create an UndoRedoCollection variable to be pushed to undo stack.
        /// </summary>
        /// <param name="sender">changes made in the winform Form1.</param>
        /// <param name="e">the datagrid cells changed.</param>
        private void DataGridView1_CellStyleChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this.changedCellsList != null && this.changedCellsList.Count != 0)
            {
                UndoRedoCollection collection = new UndoRedoCollection();
                collection.SetOriginalCell(this.changedCellsList);
                collection.SetAlteredData(this.changedCellText);
                collection.SetOperationName("Color Change");
                this.demoSpreadSheet.AddUndo(collection);
                this.changedCellsList = new List<Cell>();
                this.changedCellText = new List<string>();
                if (!this.demoSpreadSheet.IsUndoEmpty() && this.demoSpreadSheet.PeekUndo() != null)
                {
                    this.button2.Enabled = true;
                    this.button2.Text = "Undo " + this.demoSpreadSheet.PeekUndo().GetOperationName();
                }
            }
        }

        /// <summary>
        /// Event that will act as the start to a change made to cells background color. This event will empty lists used to store changed cell information.
        /// With each iteration of the cells selected, it will update both lists with cell position and values respectively.
        /// </summary>
        /// <param name="sender">changes made in winform Form1.</param>
        /// <param name="e">selected range of cells in datagridview1.</param>
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection collection = this.dataGridView1.SelectedCells;
            this.changedCellsList = new List<Cell>();
            this.changedCellText = new List<string>();
            foreach (DataGridViewCell cell in collection)
            {
                this.changedCellsList.Add(this.demoSpreadSheet.GetCell(cell.RowIndex, cell.ColumnIndex));

                // this.changedCellText.Add(this.demoSpreadSheet.GetCell(cell.ColumnIndex, cell.RowIndex).BGColor.ToString());
                this.changedCellText.Add(this.dataGridView1.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Style.BackColor.ToArgb().ToString());
            }
        }

        /// <summary>
        /// Form Load method. Not utilized in HW10.
        /// </summary>
        /// <param name="sender">Form1.</param>
        /// <param name="e">The loading of a winform.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// This button click will be to change the color of selected cells.
        /// </summary>
        /// <param name="sender">winform.Form1.</param>
        /// <param name="e">Clicking the color button.</param>
        private void Button1_Click(object sender, EventArgs e)
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            this.colorDialog1.ShowDialog();
            style.BackColor = this.colorDialog1.Color;
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
                {
                    if (this.dataGridView1.SelectedCells.Contains(this.dataGridView1.Rows[i].Cells[j]))
                    {
                        this.dataGridView1.Rows[i].Cells[j].Style = style;

                        // dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.FromArgb(unchecked((int)0xFF00FFFF));
                        this.demoSpreadSheet.GetCell(i, j).BGColor = (uint)this.dataGridView1.Rows[i].Cells[j].Style.BackColor.ToArgb();
                    }
                }
            }
        }

        /// <summary>
        /// This button will be to undo any changes made to the datagrid.
        /// </summary>
        /// <param name="sender">winform.Form1.</param>
        /// <param name="e">clicking the undo button.</param>
        private void Button2_Click(object sender, EventArgs e)
        {
            if (!this.demoSpreadSheet.IsUndoEmpty() && this.demoSpreadSheet.PeekUndo() != null)
            {
                UndoRedoCollection change = this.demoSpreadSheet.RemoveUndo();
                List<string> newData = new List<string>();
                for (int index = 0; index < change.GetOriginalCell().Count; index++)
                {
                    Cell cell = change.GetOriginalCell()[index];
                    switch (change.GetOperationName())
                    {
                        case "Color Change":
                            newData.Add(this.dataGridView1.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Style.BackColor.ToArgb().ToString());
                            this.dataGridView1.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Style.BackColor = Color.FromArgb(Convert.ToInt32(change.GetAlterdData()[index]));
                            this.demoSpreadSheet.GetCell(cell.RowIndex, cell.ColumnIndex).BGColor = (uint)this.dataGridView1.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Style.BackColor.ToArgb();

                            break;
                        case "Text Change":
                            object dataGridViewCellContet = this.demoSpreadSheet.GetCell(cell.RowIndex, cell.ColumnIndex).Text;
                            string dataGridViewCellString = dataGridViewCellContet == null ? null : dataGridViewCellContet.ToString();
                            newData.Add(dataGridViewCellString);
                            this.demoSpreadSheet.GetCell(cell.RowIndex, cell.ColumnIndex).Text = change.GetAlterdData()[index];
                            this.demoSpreadSheet.UnsubscribeReferenceVariable(cell.RowIndex, cell.ColumnIndex);
                            this.dataGridView1.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Value = this.demoSpreadSheet.GetCell(cell.RowIndex, cell.ColumnIndex).Value;
                            break;
                        default:
                            break;
                    }
                }

                change.SetAlteredData(newData);
                this.demoSpreadSheet.AddRedo(change);
                if (this.demoSpreadSheet.IsUndoEmpty())
                {
                    this.button2.Enabled = false;
                    this.button2.Text = "Undo";
                }

                this.button3.Enabled = true;
                this.button3.Text = "Redo " + this.demoSpreadSheet.PeekRedo().GetOperationName();
            }
        }

        /// <summary>
        /// This button will be to redo any undo's made.
        /// </summary>
        /// <param name="sender">winform.Form1.</param>
        /// <param name="e">clicking the undo button.</param>
        private void Button3_Click(object sender, EventArgs e)
        {
            if (!this.demoSpreadSheet.IsRedoEmpty() && this.demoSpreadSheet.PeekRedo() != null)
            {
                UndoRedoCollection change = this.demoSpreadSheet.RemoveRedo();
                List<string> newData = new List<string>();
                for (int index = 0; index < change.GetOriginalCell().Count; index++)
                {
                    Cell cell = change.GetOriginalCell()[index];
                    switch (change.GetOperationName())
                    {
                        case "Color Change":
                            newData.Add(this.dataGridView1.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Style.BackColor.ToArgb().ToString());
                            this.dataGridView1.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Style.BackColor = Color.FromArgb(Convert.ToInt32(change.GetAlterdData()[index]));
                            this.demoSpreadSheet.GetCell(cell.RowIndex, cell.ColumnIndex).BGColor = (uint)this.dataGridView1.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Style.BackColor.ToArgb();

                            break;
                        case "Text Change":
                            object dataGridViewCellContet = this.demoSpreadSheet.GetCell(cell.RowIndex, cell.ColumnIndex).Text;
                            string dataGridViewCellString = dataGridViewCellContet == null ? null : dataGridViewCellContet.ToString();
                            newData.Add(dataGridViewCellString);
                            this.demoSpreadSheet.GetCell(cell.RowIndex, cell.ColumnIndex).Text = change.GetAlterdData()[index];
                            this.dataGridView1.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Value = this.demoSpreadSheet.GetCell(cell.RowIndex, cell.ColumnIndex).Value;
                            break;
                        default:
                            break;
                    }
                }

                change.SetAlteredData(newData);
                this.demoSpreadSheet.AddUndo(change);
                if (this.demoSpreadSheet.IsRedoEmpty())
                {
                    this.button3.Enabled = false;
                    this.button3.Text = "Redo";
                }

                this.button2.Enabled = true;
                this.button2.Text = "Unddo " + this.demoSpreadSheet.PeekUndo().GetOperationName();
            }
        }

        /// <summary>
        /// Button4 will create an xml file and store the cell "name", color and text values using XmlWriter. Will utilize the saveXmlFile method from
        /// the Spreadsheet class.
        /// </summary>
        /// <param name="sender">form1.</param>
        /// <param name="e">clicking the SaveXmlFile button.</param>
        private void Button4_Click(object sender, EventArgs e)
        {
            this.demoSpreadSheet.SaveXmlFile("HW10_XMLTest.xml");
        }

        /// <summary>
        /// Button5 will clear the current spreadsheet and will read a passed xml stream. the information in the xml file will populate the new spreadsheet with
        /// any cells that are not the default setup.
        /// </summary>
        /// <param name="sender">form1.</param>
        /// <param name="e">clicking LoadXmlFile button.</param>
        private void Button5_Click(object sender, EventArgs e)
        {
            this.demoSpreadSheet.ClearSpreadSheet(this.demoSpreadSheet.RowCount, this.demoSpreadSheet.ColumnCount);
            this.demoSpreadSheet.LoadXmlFile("HW10_XMLTest.xml");
            this.demoSpreadSheet.ClearUndoStack();
            this.demoSpreadSheet.ClearRedoStack();
        }
    }
}
