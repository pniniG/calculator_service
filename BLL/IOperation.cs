using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
   public  interface IOperation
    {
         string Name { get; }
        double calculate(double first, double second);

    }
}
