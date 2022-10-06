using DemoApp.Sites;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Companies
{
    public class CreateCompanyDto
    {
        public string Code { get; set; }

        public string Nom { get; set; }

        public ICollection<CreateSiteDto> Sites { get; set; }
    }
}
