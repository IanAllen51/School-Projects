// <copyright file="AdditionOperatorNode.cs" company="Ian Allen, SID:011740734">
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
    /// AdditionOperatorNode will be the specific operatorNode used in an addition expression.
    /// </summary>
    public class AdditionOperatorNode : OperatorNode
    {
        /// <summary>
        /// Gets the operator char.
        /// </summary>
        public static char Operator => '+';

        /// <summary>
        /// Gets the precedence of a node to determine action on branches.
        /// </summary>
        public static ushort Precedence => 7;

        /// <summary>
        /// Gets the associative direction for which branch will be acted on first with the operator.
        /// </summary>
        public static Associative Associativity => Associative.Left;

        /// <summary>
        /// Evaluate will add the left and right branch values.
        /// </summary>
        /// <returns>sum of left and right branches being added.</returns>
        public override double Evaluate()
        {
            return this.Left.Evaluate() + this.Right.Evaluate();
        }

        /// <summary>
        /// Helper method passed from OperatorNode class to get Precedence value.
        /// </summary>
        /// <returns>ushort Precedence value.</returns>
        public override ushort GetPrecedence()
        {
            return Precedence;
        }

        /// <summary>
        /// Helper method to pass the associativity.
        /// </summary>
        /// <returns>Returns the associativity.</returns>
        public override Associative GetAssociative()
        {
            return Associativity;
        }
    }
}
