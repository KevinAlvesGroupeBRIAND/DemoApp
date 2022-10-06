using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Sites
{
    public class UpdateSiteDto
    {
        public Guid CompanyId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }
    }
}
