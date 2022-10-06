using DemoApp.Sites;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Companies
{
    public class UpdateCompanyDto
    {
        public string Code { get; set; }

        public string Nom { get; set; }

        public ICollection<UpdateSiteDto> Sites { get; set; }
    }
}
