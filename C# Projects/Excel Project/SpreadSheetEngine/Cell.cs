// <copyright file="Cell.cs" company="Ian Allen, SID: 011740734">
// Copyright (c) Ian Allen, SID: 011740734. All rights reserved.
// </copyright>

namespace SpreadSheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// Abstract Cell class that will form the base for the Spreadsheet class that will be utilized in spreadsheet application.
    /// </summary>
    public abstract class Cell : INotifyPropertyChanged
    {
        // NEWLY ADDED FOR HW8

        /// <summary>
        /// protected uint that will represent the hex value of the color of background.
        /// </summary>
        protected uint bGColor;

        /// <summary>
        /// protected string variable that will be utilized by the spreadsheetcell class.
        /// </summary>
        protected string text;

        /// <summary>
        /// protected string variable that will can be read, but needs to be set via the inherited spreadsheet class.
        /// </summary>
        protected string value;

        /// <summary>
        /// variable for the row index of each cell.
        /// </summary>
        private readonly int rowIndex;

        /// <summary>
        /// variable for the column index of each cell.
        /// </summary>
        private readonly int columnIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// Cell class will act as the base inheritance for the spreasheet cell that will actually create instances of "cells".
        /// </summary>
        /// <param name="row">row index.</param>
        /// <param name="col">column index.</param>
        protected Cell(int row, int col)
        {
            this.rowIndex = row;
            this.columnIndex = col;

            // NEWLY ADDED FOR HW8
            this.bGColor = 0xFFFFFFFF;
        }

        /// <summary>
        /// Event Handler that will keep track of all changes made to the cell class.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { }; // (sender, e) => is the replacement for delegate

        /// <summary>
        /// Gets the rowIndex of a cell variable.
        /// </summary>
        public int RowIndex
        {
            get { return this.rowIndex; }
        }

        /// <summary>
        /// Gets the columnIndex of cell variable.
        /// </summary>
        public int ColumnIndex
        {
            get { return this.columnIndex; }
        }

        /// <summary>
        /// Gets or Sets the text property. If text and value are not equal, it will fire a propertychanged event.
        /// </summary>
        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                if (value == this.text)
                {
                    return;
                }

                this.text = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("Text"));
            }
        }

        // NEWLY ADDED FOR HW8

        /// <summary>
        /// Gets or sets background color for cells in datagridview.
        /// </summary>
        public uint BGColor
        {
            get
            {
                return this.bGColor;
            }

            set
            {
                if (value == this.bGColor)
                {
                    return;
                }

                this.bGColor = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("BGColor"));
            }
        }

        /// <summary>
        /// Gets the string value of cell variable.
        /// </summary>
        public string Value
        {
            get { return this.value; }
        }

        /// <summary>
        /// Event that will trigger the PropertyChanged Event so Spreadsheet know this cell needs to be re-evaluated.
        /// </summary>
        /// <param name="sender">Event occurring.</param>
        /// <param name="e">changes made to the cell.</param>
        public void PropertyEventChangeHanlder(object sender, EventArgs e)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs("ReferenceCellChanged"));
        }
    }
}
