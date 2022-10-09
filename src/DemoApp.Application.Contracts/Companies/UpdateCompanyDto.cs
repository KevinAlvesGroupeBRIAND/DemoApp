using DemoApp.Companies.Childs;
using DemoApp.Sites;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Companies
{
    public class UpdateCompanyDto
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public ICollection<SiteOfUpdateCompanyDto> Sites { get; set; }
    }
}
