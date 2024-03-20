// <copyright file="ExpressionTreeNode.cs" company="Ian Allen, SID:011740734">
// Copyright(c) Ian Allen, SID:011740734. All rights reserved.
// </copyright>

namespace ExpressionTreeEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// ExpressionTreeNode will be the base class for all node classes. Utilizing the Evaluate method.
    /// </summary>
    public abstract class ExpressionTreeNode
    {
        /// <summary>
        /// Evaluate is a method to return the given value. Will differ between overridden methods in other nodes.
        /// </summary>
        /// <returns>double.</returns>
        public abstract double Evaluate();
    }
}
