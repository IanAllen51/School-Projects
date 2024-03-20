// <copyright file="SpreadSheetCell.cs" company="Ian Allen, SID: 011740734">
// Copyright (c) Ian Allen, SID: 011740734. All rights reserved.
// </copyright>

namespace SpreadSheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// SpreadsheetCell class will inherit the abstract class cell and be used to create actual cells (spreadsheetcells).
    /// SpreadsheetCell class will inherit all the base functionality of the cell class.
    /// </summary>
    public class SpreadsheetCell : Cell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpreadsheetCell"/> class.
        /// Utilizes the Cell class base functionality.
        /// </summary>
        /// <param name="row">row index of cell.</param>
        /// <param name="col">column index of cell.</param>
        public SpreadsheetCell(int row, int col)
            : base(row, col)
        {
        }

        /// <summary>
        /// Sets the value of the SpreadsheetCell using the abstract data passed.
        /// </summary>
        /// <param name="value">string that will update the value either original or = reference.</param>
        public void SetValue(string value)
        {
            this.value = value;
        }
    }
}
