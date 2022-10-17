using DemoApp.Sites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace DemoApp.Companies
{
    public class Company : FullAuditedAggregateRoot<Guid?>
    {
        public virtual string Code { get; set; }

        public virtual string Name { get; set; }

        public virtual ICollection<Site> Sites { get; set; }

    }
}
