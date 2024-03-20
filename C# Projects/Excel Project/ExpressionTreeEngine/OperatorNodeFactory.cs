// <copyright file="OperatorNodeFactory.cs" company="Ian Allen, SID:011740734">
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
    /// OperatorNodeFactory will be a factory that will automatically generate expressionTreeNodes based on the given parameters.
    /// </summary>
    internal class OperatorNodeFactory
    {
        /// <summary>
        /// Generates an operatorNode based on the operator symbol read in the expressionTree class.
        /// </summary>
        /// <param name="operatorChar">char that will be read in the expressionTree class.</param>
        /// <returns>returns a specific operator node given the read.</returns>
        public static OperatorNode GetOperator(char operatorChar)
        {
            OperatorNode operatorNode;

            // determine what type of operatorNode will be stored.
            switch (operatorChar)
            {
                case '+':
                    operatorNode = new AdditionOperatorNode();
                    break;
                case '-':
                    operatorNode = new SubtractionOperatorNode();
                    break;
                case '*':
                    operatorNode = new MultiplyOperatorNode();
                    break;
                case '/':
                    operatorNode = new DivideOperatorNode();
                    break;
                default:
                    operatorNode = null; // for compile purpose.
                    break;
            }

            return operatorNode;
        }
    }
}
