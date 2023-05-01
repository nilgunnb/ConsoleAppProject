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
        public Task<string> CreateAsync(int id, string name, double price, double discountprice, BookCategory category, bool instock);
        public Task<string> DeleteAsync(int wId, int bId);
        public Task<string> UpdateAsync(int wId, int bId, string name, double price, double discountprice, bool instock);
        public Task<Book> GetAsync(int wId, int bId);
        public Task GetAll();
        public Task<string> BuyBookAsync(int wId, int bId, bool inStock);


    }
}


