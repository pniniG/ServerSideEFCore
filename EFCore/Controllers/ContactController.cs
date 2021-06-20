using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreBll;
using EFCoreDal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EFCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
       
        IContactBll contactBll;
        public ContactController(IContactBll ContactBll)
        {
            this.contactBll = ContactBll;
        }
        [HttpGet("")]
        public async Task<List<TblContact>> GetAllAsync()
        {
            return await this.contactBll.GetAllAsync();
        }
        [HttpGet("getByGroup/{category}")]
        public async Task<List<TblContact>> GetByGroup(int category)
        {
            return await contactBll.GetByCategoryAsync(category);
        }
        [HttpPost("AddContact")]
        public async Task<List<TblContact>> Post([FromBody] TblContact c)
        {
            await contactBll.AddContactAsync(c);
            return await contactBll.GetAllAsync();
        }

        // PUT api/values/5
        [HttpPut("updateContact")]
        public async Task<List<TblContact>> UpdateContact([FromBody] TblContact c)
        {
            await contactBll.UpdateAsync(c);
            return await contactBll.GetAllAsync();
        }

        // DELETE api/values/5
        [HttpDelete("DeleteContact/{id}")]
        public async Task<List<TblContact>> DeleteContact(string n)
        {
            contactBll.Delete(n);
            return await contactBll.GetAllAsync();
        }

      
    }
}
