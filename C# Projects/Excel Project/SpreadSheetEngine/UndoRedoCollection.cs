// <copyright file="UndoRedoCollection.cs" company="Ian Allen, SID:011740734">
// Copyright(c) Ian Allen, SID:011740734. All rights reserved.
// </copyright>

namespace SpreadSheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class that will store the data of cells that have been altered in Form1. Will be stored in stacks to utilize
    /// the undo and redo methods.
    /// </summary>
    public class UndoRedoCollection
    {
        // original cells

        /// <summary>
        /// List of cells that represent the data before being changed.
        /// </summary>
        private List<Cell> originalCells;

        /// <summary>
        /// List of Text for the cells that have been stored in orignalCells.
        /// </summary>
        private List<string> alteredData;

        /// <summary>
        /// string that will represent the type of operation changed. either color change or text change.
        /// </summary>
        private string operationName;

        /// <summary>
        /// Initializes a new instance of the <see cref="UndoRedoCollection"/> class.
        /// </summary>
        public UndoRedoCollection()
        {
        }

        /// <summary>
        /// Helper method to return list of cells in originalCells list.
        /// </summary>
        /// <returns>List of Cells.</returns>
        public List<Cell> GetOriginalCell()
        {
            return this.originalCells;
        }

        /// <summary>
        /// Helper method to initialize originalCells List.
        /// </summary>
        /// <param name="origCell">List of cells collected to represent changed cells.</param>
        public void SetOriginalCell(List<Cell> origCell)
        {
            this.originalCells = origCell;
        }

        /// <summary>
        /// Helper method to get the list of text in changed cells.
        /// </summary>
        /// <returns>List of strings representing the text in each of the changed cells passed into variable.</returns>
        public List<string> GetAlterdData()
        {
            return this.alteredData;
        }

        /// <summary>
        /// Helper method to pass list of strings representing text.
        /// </summary>
        /// <param name="altData">List of strings representing the text of changed cells.</param>
        public void SetAlteredData(List<string> altData)
        {
            this.alteredData = altData;
        }

        /// <summary>
        /// Helper method to get the operation type.
        /// </summary>
        /// <returns>returns either color or text change string.</returns>
        public string GetOperationName()
        {
            return this.operationName;
        }

        /// <summary>
        /// Helper method to set opertion.
        /// </summary>
        /// <param name="opName">String representing the operation of the UndoRedoCollection variable.</param>
        public void SetOperationName(string opName)
        {
            this.operationName = opName;
        }
    }
}
