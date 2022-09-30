using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eticaret.Data.Entities;
using Eticaret.Data.EntityFramework.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Data.EntityFramework.Repositories.Concrete
{
    public class EF_Products_Repository : EF_EntityRepositoryBase<Product>, IEF_Products_Repository
    {
        public EF_Products_Repository(DbContext context) : base(context)
        {

        }
    }
}
