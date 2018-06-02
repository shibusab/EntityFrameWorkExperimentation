using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinqQueryObjects.Model
{
    public class WorkorderAudit
    {
        public int Id { get;set;}
        public int EnterpriseId { get; set; }
        public int StatusId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}