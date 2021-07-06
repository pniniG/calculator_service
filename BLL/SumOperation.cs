using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    //  class to calulate sum
    internal class SumOperation : IOperation
    {
        public string Name {
            get { return "+"; }
        }

        public double calculate(double first, double second)
        {
            return first + second;
                }
    }
}
