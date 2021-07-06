using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    internal class DiffOperation : IOperation
    {
        public string Name {
            get { return "-"; }
        }

        public double calculate(double first, double second)
        {
            return first - second;
                }
    }
}
