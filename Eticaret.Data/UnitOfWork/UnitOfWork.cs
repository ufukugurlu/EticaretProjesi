using Eticaret.Data.EntityFramework;
using Eticaret.Data.EntityFramework.Repositories.Abstract;
using Eticaret.Data.EntityFramework.Repositories.Concrete;

namespace Eticaret.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EticaretDBContext _context;
        private EF_Basket_Repository EFBasketRepository;
        private EF_Users_Repository EFUsersRepository;
        private EF_Products_Repository EFProductsRepository;

        public UnitOfWork(EticaretDBContext context)
        {
            _context = context;
            EFBasketRepository = new EF_Basket_Repository(_context);
            EFUsersRepository = new EF_Users_Repository(_context);
            EFProductsRepository = new EF_Products_Repository(_context);
        }
        public IEF_Basket_Repository IEFBasketRepository => EFBasketRepository ?? new EF_Basket_Repository(_context);
        public IEF_Users_Repository IEFUsersRepository => EFUsersRepository ?? new EF_Users_Repository(_context);
        public IEF_Products_Repository IEFProductsRepository => EFProductsRepository ?? new EF_Products_Repository(_context);

        public int Commit()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
