﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace demoMid2
{
    class Square : Shape
    {
        private string type = "Square";
        private int baseSize;
        private int index;
        private double area;
        private char symbol;

        public Square(int Indx)
        {
            this.index = Indx;
            this.baseSize = 1;
            this.symbol = 's';
        }

        public override int Index
        {
            get { return index; }
            set { this.index = value; }
        }

        public override int BaseSize
        {
            get { return baseSize; }
            set { this.baseSize = value; }
        }

        public override char Symbol
        {
            get { return symbol; }
            set { this.symbol = value; }
        }

        public override int GetSize()
        {
            return this.index * this.baseSize;
        }

        public override double GetArea()
        {
            double size = this.index * this.baseSize;
            this.area = size * size;
            return this.area;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine(this.type + ":");
            Console.WriteLine("  Size: " + this.index * this.baseSize);
            Console.WriteLine("  Area: " + GetArea());
            Console.WriteLine("  Symbol: " + this.symbol);
            Console.WriteLine();
        }
    }
}
