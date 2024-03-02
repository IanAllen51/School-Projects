using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace demoMid2
{
    public abstract class Shape
    {
        private int baseSize = 1;
        private int index;
        private char symbol;
        

        public abstract char Symbol { get; set; }

        public abstract int BaseSize { get; set;}
        
        public abstract int Index { get; set;}

        public abstract int GetSize();

        public abstract double GetArea();
        public abstract void DisplayInfo();
    }
}
