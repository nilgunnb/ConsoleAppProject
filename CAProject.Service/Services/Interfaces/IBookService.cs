using CAProject.Core.Enums;
using CAProject.Core.Models.Minor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAProject.Service.Services.Interfaces
{
    public interface IBookService
    {
        public Task<string> CreateAsync(int id, string name, double price, double discountprice, BookCategory category);
        public Task<string> DeleteAsync(int wId, int bId);
        public Task<string> UpdateAsync(int wId, int bId, string name, double price, double discountprice);
        public Task<Book> GetAsync(int wId, int bId);
        public Task GetAll();
        
    }
}


