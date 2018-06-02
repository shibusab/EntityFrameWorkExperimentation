using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqQueryObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            var startDate = new DateTime(2018, 05, 12);
            var endDate = new DateTime(2018, 05, 13);
            
            using (var context = new WorkOrderContext())
            {
                var custom_query = context.Workorder.SearchByEnterprise(1002).SearchByStatus(1).SearchBetweenClosedDates(startDate, endDate);
                var results= custom_query.ToList();
            }
        }
    }
}
