using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace DemoApp.Companies.Childs
{
    public class SiteOfCompanyDto : FullAuditedEntityDto<Guid>
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
