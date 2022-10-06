using DemoApp.Companies;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace DemoApp.Sites
{
    public class SiteDto : FullAuditedEntityDto<Guid>
    {
        public Guid CompanyId { get; set; }

        //public CompanyDto Company { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }
    }
}
