// <copyright file="OperatorNode.cs" company="Ian Allen, SID:011740734">
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
    /// OperatorNode will be the symbol (operator) and the following branches that it is operating on.
    /// </summary>
    public abstract class OperatorNode : ExpressionTreeNode
    {
        /// <summary>
        /// Associative enumeration will determine which branch (Left or Right) will be utilized.
        /// </summary>
        public enum Associative
        {
            /// <summary>
            /// Right will be the right branch of a given node.
            /// </summary>
            Right,

            /// <summary>
            /// Left will be the left branch of a given node.
            /// </summary>
            Left,
        }

        /// <summary>
        /// Gets or sets left branch of node.
        /// </summary>
        public ExpressionTreeNode Left { get; set; }

        /// <summary>
        /// Gets or sets right branch of node.
        /// </summary>
        public ExpressionTreeNode Right { get; set; }

        /// <summary>
        /// Helper Method for inherited classes to get Precedence value.
        /// </summary>
        /// <returns>nothing in abstract class, but ushort Precedence value in inherited classes.</returns>
        public abstract ushort GetPrecedence();

        /// <summary>
        /// Helper method to pass the associativity.
        /// </summary>
        /// <returns>Returns the associativity.</returns>
        public abstract Associative GetAssociative();
    }
}