using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eticaret.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Data.EntityFramework.Repositories.Concrete
{
    public class EF_Users_Repository : EF_EntityRepositoryBase<User>, Abstract.IEF_Users_Repository
    {
        private DbContext _context;
        private DbSet<User> _dbSet_Users;
        public EF_Users_Repository(EticaretDBContext context) : base(context)
        {
            _context = context;
            _dbSet_Users = context.Users;
        }

        public User fnLogin(User entity)
        {
            User _EF = _dbSet_Users.Where(a => (a.Email.Equals(entity.Email) && a.Password.Equals(entity.Password))).FirstOrDefault();
            if (_EF != null)
            {
                entity.Id = _EF.Id;
            }
            return _EF;
        }
    }
}
