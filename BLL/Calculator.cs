using BLL.Models;
using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Calculator : ICalculator
    {
        DB db;

        public List<IOperation> Operators { get; set; }
       public Calculator(DB _db)
        {
            db = _db;
            Operators = new List<IOperation>()
            {
                 new SumOperation(),new DiffOperation()
            };
        }
     
        // calculate the result 
        public double calculate(Calculation calculation,string userID)
        {
            
             // search right class to send the  calculation 
            foreach (var binaryOperator in Operators.Where(x => x.Name == calculation.Operator))
            {
                calculation.Result= binaryOperator.calculate(calculation.Number1, calculation.Number2);
                db.addOrUpdateCalculationToDB(calculation, userID);
                return calculation.Result;
            }
            throw new Exception("not calculate");
                }

       
    }
}

     
    
