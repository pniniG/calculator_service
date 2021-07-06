using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
   public interface ICalculator
    {
        List<IOperation> Operators { get; set; }
        double calculate(Calculation calculation, string useId);

      
    }
}
