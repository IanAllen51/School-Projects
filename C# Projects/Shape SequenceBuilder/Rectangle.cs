using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoMid2
{
    class Rectangle : Shape
    {
        private string type = "Rectangle";
        private int baseSize;
        private int index;
        private double width;
        private double area;
        private char symbol;

        public Rectangle(int Indx)
        {
            this.index = Indx;
            this.baseSize = 1;
            this.symbol = 'r';
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

        public override double GetArea()
        {
            double size = this.baseSize * this.index;
            this.width = size / 2.0;
            this.area = this.width * size;
            return this.area;
        }

        public override int GetSize()
        {
            return this.index * this.baseSize;
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
