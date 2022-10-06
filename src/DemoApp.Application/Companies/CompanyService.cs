using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace DemoApp.Companies
{
    [AllowAnonymous]
    public class CompanyService : ApplicationService, ICompanyService
    {
        public string GetResponse()
        {
            return "OK";
        }
    }
}
