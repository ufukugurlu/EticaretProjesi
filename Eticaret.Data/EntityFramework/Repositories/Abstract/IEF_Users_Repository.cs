using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eticaret.Data.Entities;

namespace Eticaret.Data.EntityFramework.Repositories.Abstract
{
    public interface IEF_Users_Repository : IEF_EntityRepositoryBase<User>
    {

        User fnLogin(User entity);
    }
}
