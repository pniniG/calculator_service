using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL
{
    public class DB
    {
        public Dictionary<string, List<Calculation>> DBCalculation { get; set; }
        public int id = 1;
        // add or update calculation to user history
        public List<Calculation> addOrUpdateCalculationToDB(Calculation calc, string userID)
        {
            try
            {
                if (DBCalculation.ContainsKey(userID))
                {
                    
                    var index = DBCalculation[userID].FindIndex(c => c.id == calc.id);
                    if (index == -1)
                    {
                        calc.id = ++id;
                        DBCalculation[userID].Insert(0,calc);
                    }
                    else
                    {
                        DBCalculation[userID][DBCalculation[userID].FindIndex(c => c.id == calc.id)] = calc; ;

                    }

                }
                else
                {
                    calc.id = ++id;

                    DBCalculation.Add(userID, new List<Calculation>()
                {
                    calc
                });
                }
                return DBCalculation[userID];

            }
            catch (Exception e)
            {

                throw e;
            }


        }

        // delete calculation from DB
        public List<Calculation> deleteCalculationFromDB(Calculation calc, string userID)
        {
            try
            {
                if (DBCalculation.ContainsKey(userID))
                {
                    var index = DBCalculation[userID].FindIndex(c => c.id == calc.id);
                    if (index != -1)
                    {

                        DBCalculation[userID].RemoveAt(index);

                    }


                }
                else
                {
                    throw new Exception(" calc not deleted");
                }
                return DBCalculation[userID];

            }
            catch (Exception e)
            {

                throw e;

            }


        }

        // init the DB
        public DB()
        {
            //var a = new List<Calculation>()
            //{
            //    new Calculation()
            //    {
            //        id=0,
            //        Number1=6,
            //        Number2=2,
            //        Operator="+",
            //        Result=3

            //    },
            //     new Calculation()
            //    {
            //        id=1,
            //        Number1=3,
            //        Number2=2,
            //        Operator="-",
            //        Result=3

            //    },
            //};
            DBCalculation = new Dictionary<string, List<Calculation>>();

            //DBCalculation.Add("DESKTOP-351U96G", a);
            //DBCalculation.Add("2", a);
            //DBCalculation.Add(9, a);

        }
    }

}