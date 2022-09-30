using Eticaret.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Data.EntityFramework
{
    public interface IEF_EntityRepositoryBase<TEntity> where TEntity : class, IEntity, new()
    {
        TEntity fnGetir(Expression<Func<TEntity, bool>> expFiltre, params Expression<Func<TEntity, object>>[] expIncludeTablolar);
        IList<TEntity> fnListele(int? intBaslangic_Degeri, int? intGosterim_Adeti, out int intToplam_Kayit, Expression<Func<TEntity, bool>> expFiltre = null, params Expression<Func<TEntity, object>>[] expIncludeTablolar);
        void fnEkle(TEntity tablo);
        void fnGuncelle(TEntity tablo);
        void fnSil(TEntity tablo);
        bool fnKontrol(Expression<Func<TEntity, bool>> expFiltre);
        int fnToplam_Kayit(Expression<Func<TEntity, bool>> expFiltre);
    }
}
