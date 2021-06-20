using EFCoreDal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace EFCoreBll
{
   public class ContactBll : IContactBll
    {
        IContactDl ContactDl;
        public ContactBll(IContactDl ContactDl)
        {
            this.ContactDl = ContactDl;
        }
        public async Task AddContactAsync(TblContact c)
        {
            await this.ContactDl.AddContactAsync(c);
        }

        public void Delete(string name)
        {
            this.ContactDl.Delete(name);
        }

        public async Task<List<TblContact>> GetAllAsync()
        {
            return await this.ContactDl.GetAllAsync();
        }

        public async Task<List<TblContact>> GetByCategoryAsync(int id)
        {
            return await this.ContactDl.GetByCategoryAsync(id);
        }

        public async Task UpdateAsync(TblContact c)
        {
            await this.ContactDl.UpdateAsync(c);
        }
    }
}
