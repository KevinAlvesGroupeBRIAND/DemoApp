using DemoApp.Sites;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace DemoApp.Companies
{
    public class CompanyDto : FullAuditedEntityDto<Guid>
    {
        public string Code { get; set; }

        public string Nom { get; set; }

        public ICollection<SiteDto> Sites { get; set; }

    }
}
