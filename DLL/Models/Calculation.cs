using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
  public  class Calculation
    {
        public int id { get; set; }

        public double Number1 { get; set; }
        public double Number2 { get; set; }
        public double Result { get; set; }
        public string Operator { get; set; }

    }
}
