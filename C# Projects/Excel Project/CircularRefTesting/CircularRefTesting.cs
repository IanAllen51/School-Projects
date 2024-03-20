// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using ExpressionTreeEngine;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace CircularRefTesting
{
    [TestFixture]
    public class CircularRefTesting
    {
        /// <summary>
        /// Generic Testing method.
        /// </summary>
        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            var answer = 42;
            Assert.That(answer, Is.EqualTo(42), "Some useful error message");
        }

        /// <summary>
        /// Testing for bad refrencing. This case will us an expression variable "Cell". As Cell is not a viable variable from the datagridview
        /// a possible constant or operator, it should not be accepted and display BadRef. In the actual code, the refstr will be an exception thrown
        /// that will be read and assigned to a cell in the datagridview.
        /// </summary>
        [Test]
        public void TestBadRefPass()
        {
            string expressionVariable = "Cell";
            string refstr = string.Empty;
            if (!char.IsUpper(expressionVariable[0]))
            {
                refstr = "!(BadRef)";
            }
            else if (!int.TryParse(expressionVariable[1].ToString(), out int result))
            {
                refstr = "!(BadRef)";
            }
            else
            {
                refstr = expressionVariable;
            }
            Assert.That(refstr, Is.EqualTo("!(BadRef)"), "Error in parsing expression");
        }

        /// <summary>
        /// Similar to the pass test above, this is simply a verification that a plausible reference will be accepted.
        /// </summary>
        [Test]
        public void TestBadRefFail()
        {
            string expressionVariable = "C5";
            string refstr = string.Empty;
            if (!char.IsUpper(expressionVariable[0]))
            {
                refstr = "!(BadRef)";
            }
            else if (!int.TryParse(expressionVariable[1].ToString(), out int result))
            {
                refstr = "!(BadRef)";
            }
            else
            {
                refstr = expressionVariable;
            }
            Assert.That(refstr, Is.EqualTo("C5"), "Error in parsing expression");
        }

        /// <summary>
        /// Testing for whether or not a expressionvariable is out of the bounds of the datagridview. In this assignment, that will be anything
        /// greater than 50. In actual program, the refstr will be an exception thrown for boundserror.
        /// </summary>
        [Test]
        public void TestBoundError()
        {
            string errorboundStr = "A65";
            string refstr = string.Empty;
            if (int.Parse(errorboundStr.Substring(1)) > 50)
            {
                refstr = "!(Bounds)";
            }
            else
            {
                refstr = errorboundStr;
            }
            Assert.That(refstr, Is.EqualTo("!(Bounds)"), "Error in parsing expression");
        }


        [Test]
        public void TestSelfRef()
        {
            string current = "A5";
            string expression = "B8+C2/A5";
            bool selfRef = false;

            ExpressionTree expTree = new ExpressionTree();
            expTree.SetExpression(expression);
            List<string> varList = expTree.ReturnVariablesNeeded();
            foreach (string var in varList)
            {
                if (var == current)
                {
                    selfRef = true;
                }
            }
            Assert.That(selfRef, Is.EqualTo(true), "Error in parsing expression.");
        }
    }
}
