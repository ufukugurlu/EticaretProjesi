using Eticaret.Data.Entities;
using Eticaret.Data.EntityFramework.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Data.EntityFramework.Repositories.Concrete
{
    public class EF_Basket_Repository : EF_EntityRepositoryBase<Basket>, IEF_Basket_Repository
    {
        public EF_Basket_Repository(DbContext context) : base(context)
        {

        }
    }
}
