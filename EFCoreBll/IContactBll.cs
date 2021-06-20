using EFCoreDal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;



namespace EFCoreBll
{
   public interface IContactBll
    {
        //הצגת רשימת כל אנשי הקשר
        Task<List<TblContact>> GetAllAsync();
        //הוספה, עדכון, מחיקה של איש קשר
        Task AddContactAsync(TblContact c);
        Task UpdateAsync(TblContact c);
        void Delete(string name);
        //הצגת רשימת אנשי קשר לפי קבוצה מסוימת
        Task<List<TblContact>> GetByCategoryAsync(int id);
    }
}
