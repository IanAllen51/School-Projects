// <copyright file="ParenthesisNode.cs" company="Ian Allen, SID:011740734">
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
    /// ParenthesisNode is a node class that will account for the occurance of a left or right Parenthesis.
    /// </summary>
    public class ParenthesisNode : ExpressionTreeNode
    {
        /// <summary>
        /// represents the left or right parenthesis symbol.
        /// </summary>
        private char parenthesis;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParenthesisNode"/> class.
        /// </summary>
        /// <param name="parens">the left or right parenthesis.</param>
        public ParenthesisNode(char parens)
        {
            this.parenthesis = parens;
        }

        /// <summary>
        /// Gets the char value for the parenthesis.
        /// </summary>
        /// <returns>returns the left or right parenthesis.</returns>
        public char GetParenthesisNode()
        {
            return this.parenthesis;
        }

        /// <summary>
        /// Evaluate method will never be called for parenthesisNode, as we do not operate on anything with appropriate value.
        /// </summary>
        /// <returns>returns double in other variations, will not actually be called in this program.</returns>
        public override double Evaluate()
        {
            return 0; // will never be called.
        }
    }
}
