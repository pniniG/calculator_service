using BLL.Models;
using DLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
   public class ListCalc : IListCalc
    {
        DB db;

        public ListCalc(DB _db)
        {
            db = _db;
            
        }
        // get calculaions history
        public List<Calculation> GetHistoryCalculation(string userID)
        {

            if (db.DBCalculation.ContainsKey(userID))
                return db.DBCalculation[userID];
            else
                return null;
        }
      //delete  from calculations history
        public List<Calculation> DeleteCalculation(string userID,Calculation calc)
        {
            return db.deleteCalculationFromDB(calc, userID);
        }
        // update  from calculations history

        public List<Calculation> UpdateCalculation(string userID, Calculation calc)
        {
            return db.addOrUpdateCalculationToDB(calc, userID);
        }
    }
}
