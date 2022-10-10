using DemoApp.Sites;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace DemoApp.Companies
{
    public class Company : FullAuditedAggregateRoot<Guid>
    {
        protected Company()
        {
            //Sites = new Collection<Site>();
        }

        public Company(Guid id) : base(id)
        {
            Sites = new Collection<Site>();
        }

        public virtual string Code { get; set; }

        public virtual string Name { get; set; }

        public virtual ICollection<Site> Sites { get; set; }

    }
}
