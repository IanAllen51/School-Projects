// <copyright file="ConstantNode.cs" company="Ian Allen, SID: 011740734">
// Copyright (c) Ian Allen, SID: 011740734. All rights reserved.
// </copyright>

namespace ExpressionTreeEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// ConstantNode will utilize the double value stored within each element of expression.
    /// </summary>
    public class ConstantNode : ExpressionTreeNode
    {
        /// <summary>
        /// double value of a given node.
        /// </summary>
        private readonly double value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantNode"/> class.
        /// </summary>
        /// <param name="value">double value.</param>
        public ConstantNode(double value)
        {
            this.value = value;
        }

        /// <summary>
        /// Evaluate will return the double value of a given node.
        /// </summary>
        /// <returns>double value.</returns>
        public override double Evaluate()
        {
            return this.value;
        }
    }
}