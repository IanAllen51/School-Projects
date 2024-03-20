// <copyright file="VariableNode.cs" company="Ian Allen, SID:011740734">
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
    /// VariableNode will contain the string value of the expression tree.
    /// </summary>
    public class VariableNode : ExpressionTreeNode
    {
        /// <summary>
        /// name of node in given expression.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// dictionary to keep track of possible variables in the expression.
        /// </summary>
        private Dictionary<string, double> variables;

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableNode"/> class.
        /// </summary>
        /// <param name="name">string of expression name.</param>
        /// <param name="variables">Dictionary reference to verify if name has been used elsewhere.</param>
        public VariableNode(string name, ref Dictionary<string, double> variables)
        {
            this.name = name;
            this.variables = variables;
        }

        /// <summary>
        /// Evalute will return the value of node. Will be 0.0 unless updated by the dictionary variables.
        /// </summary>
        /// <returns>double value.</returns>
        public override double Evaluate()
        {
            double value = 0.0;
            if (this.variables.ContainsKey(this.name))
            {
                value = this.variables[this.name];
            }
            else
            {
                throw new NullReferenceException(this.name);
            }

            return value;
        }
    }
}
