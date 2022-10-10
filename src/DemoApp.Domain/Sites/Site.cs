using DemoApp.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace DemoApp.Sites
{
    public class Site : AuditedEntity<Guid>
    {
        protected Site()
        {
            /* This constructor is for ORMs to be used while getting the entity from database. */
        }

        public Site(Guid id) : base(id)
        {

        }

        public virtual Guid CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public virtual string Code { get; set; }

        public virtual string Name { get; set; }

    }
}
