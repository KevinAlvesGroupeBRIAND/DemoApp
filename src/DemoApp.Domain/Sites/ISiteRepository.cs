using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace DemoApp.Sites
{
    public interface ISiteRepository : IRepository<Site, Guid?>
    {
    }
}
