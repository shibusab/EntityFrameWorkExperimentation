using LinqQueryObjects.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqQueryObjects
{
    public static class WoEntityExtension
    {
        public static IQueryable<Workorder> SearchByEnterprise(this IQueryable<Workorder> queryable, int enterpriseId)
        {
            return queryable.Where(searchField => searchField.EnterpriseId.Equals(enterpriseId));
        }

        public static IQueryable<Workorder> SearchByStatus(this IQueryable<Workorder> queryable, int statusId)
        {
            return queryable.Where(searchField => searchField.StatusId.Equals(statusId));
        }

        public static IQueryable<Workorder> SearchBetweenClosedDates(this IQueryable<Workorder> queryable, DateTime fromDate, DateTime toDate)
        {
            return queryable.Where(outerSearch => outerSearch.WorkorderAudits.Any(searchField => searchField.DateCreated >= fromDate && searchField.DateCreated <= toDate));
        }
    }
}
