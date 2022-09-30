using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eticaret.Data.EntityFramework.Repositories.Abstract;

namespace Eticaret.Data.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {

        IEF_Basket_Repository IEFBasketRepository { get; }
        IEF_Products_Repository IEFProductsRepository { get; }
        IEF_Users_Repository IEFUsersRepository { get; }

        int Commit();
        void Dispose();

    }
}
