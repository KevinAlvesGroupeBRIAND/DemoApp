using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace DemoApp.Companies
{
    public interface ICompanyService : IApplicationService
    {
        public string GetResponse();
    }
}
