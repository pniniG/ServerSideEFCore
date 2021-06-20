using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreDal.Models
{
    public partial class TblContact
    {
      
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAdress { get; set; }
        public int? CategoryId { get; set; }

        public virtual TblCategory Category { get; set; }
    }
}
