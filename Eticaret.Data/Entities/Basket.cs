using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Eticaret.Data.Entities
{
    [Serializable]
    public class Basket: IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
       // public User KEY_UserId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Total { get; set; }

    }
}
