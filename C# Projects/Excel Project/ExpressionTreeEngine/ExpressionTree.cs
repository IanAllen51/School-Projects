// <copyright file="ExpressionTree.cs" company="Ian Allen, SID: 011740734">
// Copyright (c) Ian Allen, SID: 011740734. All rights reserved.
// </copyright>

namespace ExpressionTreeEngine
{
    using System;
    using System.CodeDom;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// ExpressionTree will generate an expression tree with operator,variable, and constant nodes.
    /// will contain methods for setting name and values, constructor, and Evaluate method to return double value.
    /// </summary>
    public class ExpressionTree
    {
        /// <summary>
        /// operatorList is a list of the operators used in ExpressionTree. specifically the four required for assignment HW5.
        /// </summary>
        private readonly char[] operatorList = { '+', '-', '*', '/' };

        /// <summary>
        /// root will be the top node in the expression tree. will be an operator.
        /// </summary>
        private ExpressionTreeNode root;

        /// <summary>
        /// List to hold the variables in an expression.
        /// </summary>
        private List<string> variableNeededForCurrentExpression = new List<string>();

        /// <summary>
        /// variables will be a dictionary of nodes and their contents to simplify altering reference lookup.
        /// </summary>
        private Dictionary<string, double> variables = new Dictionary<string, double>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// </summary>
        /// <param name="expression">string to be converted to expressionTree.</param>
        public ExpressionTree()
        {
        }

        /// <summary>
        /// Helper method to generate an expression tree.
        /// </summary>
        /// <param name="expression">string of expression entered into cells.</param>
        public void SetExpression(string expression)
        {
            List<ExpressionTreeNode> expressionTreeNodes = this.ParseExpression(expression);

            foreach (string str in this.variableNeededForCurrentExpression)
            {
                if (!char.IsUpper(str[0]))
                {
                    throw new ArithmeticException("!(badRef)");
                }

                if (!int.TryParse(str[1].ToString(), out int result))
                {
                    throw new ArithmeticException("!(badRef)");
                }

                if (int.Parse(str.Substring(1)) > 50)
                {
                    throw new ArithmeticException("!(Bounds)");
                }
            }

            List<ExpressionTreeNode> expressionPostFix = this.ConvertToPostFix(expressionTreeNodes);
            this.root = this.ConstructTree(expressionPostFix);
        }

        /// <summary>
        /// SetVariable will update the name and variable value within the tree.
        /// </summary>
        /// <param name="variableName">string new name.</param>
        /// <param name="variableValue">double new value.</param>
        public void SetVariable(string variableName, double variableValue)
        {
            if (this.variables.ContainsKey(variableName))
            {
                this.variables[variableName] = variableValue;
            }
            else
            {
                this.variables.Add(variableName, variableValue);
            }
        }

        /// <summary>
        /// Helper method to get the list of variables in an expression.
        /// </summary>
        /// <returns>list of strings representing the variables in an expression.</returns>
        public List<string> ReturnVariablesNeeded()
        {
            return this.variableNeededForCurrentExpression;
        }

        /// <summary>
        /// Evaluate will evalutate the entire Expression tree starting from the root node.
        /// </summary>
        /// <returns>double value.</returns>
        public double Evaluate()
        {
            return this.root.Evaluate();
        }

        /// <summary>
        /// Helper method to generate the expression string into a list of expressiontreenodes to be used in the postfix and tree construction.
        /// </summary>
        /// <param name="expression">string passed during tree construction.</param>
        /// <returns>list of expressionTreeNodes.</returns>
        private List<ExpressionTreeNode> ParseExpression(string expression)
        {
            this.variableNeededForCurrentExpression.Clear(); // empty list for each expression.
            char[] expressionArray = expression.ToArray();
            List<ExpressionTreeNode> expressionList = new List<ExpressionTreeNode>();
            string nodeName = string.Empty;
            double number;
            ExpressionTreeNode operandNode = null;
            ParenthesisNode parensNode = null;

            for (int index = 0; index < expressionArray.Length; index++)
            {
                if (expressionArray[index] == '(' || expressionArray[index] == ')')
                {
                    if (!string.IsNullOrEmpty(nodeName))
                    {
                        if (double.TryParse(nodeName, out number))
                        {
                            operandNode = new ConstantNode(number);
                        }

                        // if not number, must be a name.
                        else
                        {
                            operandNode = new VariableNode(nodeName, ref this.variables);
                            this.variableNeededForCurrentExpression.Add(nodeName); // add string to list of variables.
                        }

                        nodeName = string.Empty;
                        expressionList.Add(operandNode);
                    }

                    parensNode = new ParenthesisNode(expressionArray[index]);
                    expressionList.Add(parensNode);
                    continue;
                }

                if (this.operatorList.Contains(expressionArray[index]))
                {
                    ExpressionTreeNode operatorNode = null;

                    if (!string.IsNullOrEmpty(nodeName))
                    {
                        if (double.TryParse(nodeName, out number))
                        {
                            operandNode = new ConstantNode(number);
                        }

                        // if not number, must be a name.
                        else
                        {
                            operandNode = new VariableNode(nodeName, ref this.variables);
                            this.variableNeededForCurrentExpression.Add(nodeName); // add string to list of variables.
                        }

                        nodeName = string.Empty;
                        expressionList.Add(operandNode);
                    }

                    operatorNode = OperatorNodeFactory.GetOperator(expressionArray[index]);

                    if (operatorNode != null)
                    {
                        expressionList.Add(operatorNode);
                    }
                }
                else
                {
                    // build on string. Meaning it could be a larger number/name.
                    nodeName += expressionArray[index];
                }
            }

            // There will be a single operand left after the last operator. Need to add to list.
            if (!string.IsNullOrEmpty(nodeName))
            {
                if (double.TryParse(nodeName, out number))
                {
                    operandNode = new ConstantNode(number);
                }
                else
                {
                    operandNode = new VariableNode(nodeName, ref this.variables);
                    this.variableNeededForCurrentExpression.Add(nodeName); // add string to list of variables.
                }

                expressionList.Add(operandNode);
            }

            return expressionList;
        }

        /// <summary>
        /// Having already generated a list of ExpressionTreeNodes, ConvertToPostFix will take that list and utilizing a stack and array,
        /// will iterate through list and will generate PostFix notation. Variable and constant nodes will be added to the array and index
        /// incremented. operators will be added to stack and based on precedence.
        /// </summary>
        /// <param name="expressionList">list of ExpressionTreeNodes generated from ParseExpression method.</param>
        /// <returns>array of expressionTreeNodes in PostFix notation.</returns>
        private List<ExpressionTreeNode> ConvertToPostFix(List<ExpressionTreeNode> expressionList)
        {
            List<ExpressionTreeNode> postFixExpression = new List<ExpressionTreeNode>();
            Stack<ExpressionTreeNode> postFixStack = new Stack<ExpressionTreeNode>();

            // iterate through the list of expressionTreeNodes
            foreach (ExpressionTreeNode node in expressionList)
            {
                if (typeof(ParenthesisNode).IsInstanceOfType(node))
                {
                    if (((ParenthesisNode)node).GetParenthesisNode() == '(')
                    {
                        postFixStack.Push(node);
                    }
                    else
                    {
                        while (!typeof(ParenthesisNode).IsInstanceOfType(postFixStack.Peek()) || ((ParenthesisNode)postFixStack.Peek()).GetParenthesisNode() != '(')
                        {
                            postFixExpression.Add(postFixStack.Pop());
                        }

                        postFixStack.Pop();
                    }
                }

                // if node is an operator node.
                else if (typeof(OperatorNode).IsInstanceOfType(node))
                {
                    // check if stack is empty or if current operator node is higher or equal in precedence to existing operator nodes on stack.
                    if (postFixStack.Count == 0 || typeof(ParenthesisNode).IsInstanceOfType(postFixStack.Peek()) || ((OperatorNode)node).GetPrecedence() < ((OperatorNode)postFixStack.Peek()).GetPrecedence())
                    {
                        postFixStack.Push(node);
                    }
                    else
                    {
                        OperatorNode tempnode = (OperatorNode)node;
                        OperatorNode peekNode = (OperatorNode)postFixStack.Peek();

                        // current operator node has lower precedence than nodes on stack.
                        while (postFixStack.Count != 0 && ((tempnode.GetPrecedence() > peekNode.GetPrecedence()) || ((tempnode.GetPrecedence() ==
                            peekNode.GetPrecedence()) && (peekNode.GetAssociative() == OperatorNode.Associative.Left))))
                        {
                            // return operator nodes on stack to array of variable/constant nodes.
                            postFixExpression.Add(postFixStack.Pop());

                            if (postFixStack.Count != 0)
                            {
                                // need to update stack peek node for each pop
                                peekNode = (OperatorNode)postFixStack.Peek();
                            }
                        }

                        postFixStack.Push(node);
                    }
                }
                else
                {
                    // Not operator node, add to postfix array.
                    postFixExpression.Add(node);
                }
            }

            // Any remaining operator nodes on stack will be added to the array.
            while (postFixStack.Count > 0)
            {
                postFixExpression.Add(postFixStack.Pop());
            }

            return postFixExpression;
        }

        /// <summary>
        /// ConstructTree will take the array of postfix nodes from converttopostfix method. Method will iterate
        /// through the entire array, pushing constant and variable nodes to stack. for each operator node that is
        /// incountered, the stack will pop the top two nodes and assign them to right and left branch and push subtree
        /// back to stack.
        /// </summary>
        /// <param name="expressionTreeNodes">postfix array of ExpressionTreeNodes generated from postfix helper method.</param>
        /// <returns>the complete expression tree.</returns>
        private ExpressionTreeNode ConstructTree(List<ExpressionTreeNode> expressionTreeNodes)
        {
            Stack<ExpressionTreeNode> treeNodeStack = new Stack<ExpressionTreeNode>();
            for (int index = 0; index < expressionTreeNodes.Count; index++)
            {
                // all nodes will be pushed to the stack. From postfix notation, there will always be at least two operand nodes,
                // therefore when the operator node occurs, there will be two operands to branch to. subtree will then be pushed to stack
                // and utilized by further operators.
                if (typeof(OperatorNode).IsInstanceOfType(expressionTreeNodes[index]))
                {
                    ((OperatorNode)expressionTreeNodes[index]).Right = treeNodeStack.Pop();
                    ((OperatorNode)expressionTreeNodes[index]).Left = treeNodeStack.Pop();
                }

                treeNodeStack.Push(expressionTreeNodes[index]);
            }

            // the entire expression tree will be the last thing on the stack, so it must be popped.
            return treeNodeStack.Pop();
        }
    }
}
