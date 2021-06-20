using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EFCoreDal.Models
{
   public class ContactDl : IContactDl
    {
        myDBContext db;
        public ContactDl(myDBContext _db)
        {
            this.db = _db;  
        }

       

        public async Task AddContactAsync(TblContact c)
        {
            db.TblContacts.Add(c);
            await db.SaveChangesAsync();
        }

        public void  Delete(string name)
        {
            db.TblContacts.Remove(db.TblContacts.FirstOrDefault(c => c.Name.Equals(name)));
            db.SaveChanges();
        }


        public async Task<List<TblContact>> GetAllAsync()
        {
            return await db.TblContacts.ToListAsync();
        }

        public async Task<List<TblContact>> GetByCategoryAsync(int id)
        {
            return await db.TblContacts.Where(e => e.CategoryId == id).ToListAsync();
        }

        public async Task UpdateAsync(TblContact c)
        {
            TblContact cto = db.TblContacts.FirstOrDefault(c => c.Name.Equals(c.Name));
            cto.PhoneNumber = c.PhoneNumber;
            cto.MailAdress = c.MailAdress;
            cto.CategoryId = c.CategoryId;
            await db.SaveChangesAsync();
        }
    }
}
