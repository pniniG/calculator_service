using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
 
   public interface IListCalc
    {
          List<Calculation> GetHistoryCalculation(string userID);
        List<Calculation> DeleteCalculation(string userID, Calculation calc);
        List<Calculation> UpdateCalculation(string userID, Calculation calc);
    }

}

