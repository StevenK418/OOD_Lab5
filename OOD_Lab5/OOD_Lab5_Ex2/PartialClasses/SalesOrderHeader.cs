using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Lab5_Ex2
{
    public partial class SalesOrderHeader
    {
        //Overrides the Tostring method of the parent object
        public override string ToString()
        {
            return string.Format(
                "{0}: {1} {2:c}",
                OrderDate.ToShortDateString(),
                SalesOrderID,
                TotalDue);
        }
    }
}
