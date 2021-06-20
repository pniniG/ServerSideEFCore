using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreDal.Models
{
    public partial class TblCategory
    {
        public TblCategory()
        {
            TblContacts = new HashSet<TblContact>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<TblContact> TblContacts { get; set; }
    }
}
