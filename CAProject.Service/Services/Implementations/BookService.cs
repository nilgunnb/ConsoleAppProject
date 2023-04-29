using CAProject.Core.Enums;
using CAProject.Core.Models.Minor;
using CAProject.Data.Repositories.BookWriters;
using CAProject.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAProject.Service.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly BookWriterRepository _repository = new BookWriterRepository();
        public async Task<string> CreateAsync(int id, string name, double price, double discountprice, BookCategory category)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            BookWriter bookwriter = await _repository.GetAsync(w => w.Id == id);

            while (!string.IsNullOrWhiteSpace(await ValidateProduct(name, price, discountprice)))
            { return await ValidateProduct(name, price, discountprice); }

            Book book = new Book(name, price, discountprice, category, bookwriter);

            bookwriter.Books.Add(book);

            Console.ForegroundColor = ConsoleColor.Green;
            return "Book is succesfully created!";
        }

        public async Task<string> DeleteAsync(int wId, int bId)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            BookWriter bookwriter = await _repository.GetAsync(w => w.Id == wId);

            if (bookwriter == null)
                return "Book is not found";

            Book book = bookwriter.Books.FirstOrDefault(b => b.Id == bId);

            if (book == null)
            { return "Book is not found"; }

            bookwriter.Books.Remove(book);

            Console.ForegroundColor = ConsoleColor.Green;
            return "Book is succesfully deleted!";
        }
        public async Task GetAll()
        {
            foreach (var item in await _repository.GetAllAsync())
            {

                foreach (var book in item.Books)
                {
                    Console.WriteLine(book);
                }
            }
        }
        public async Task<Book> GetAsync(int wId, int bId)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            BookWriter bookwriter = await _repository.GetAsync(w => w.Id == wId);

            if (bookwriter == null)
            {
                Console.WriteLine("Author is not found");
                return null;
            }
            Book book = bookwriter.Books.FirstOrDefault(b => b.Id == bId);

            if (book == null)
            {
                Console.WriteLine("Book is not found");
                return null;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            return book;
        }

        public async Task<string> UpdateAsync(int wId, int bId, string name, double price, double discountprice)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            BookWriter bookwriter = await _repository.GetAsync(w => w.Id == wId);

            if (bookwriter == null)
            { return "Author is not found"; }

            while (!string.IsNullOrWhiteSpace(await ValidateProduct(name, price, discountprice)))
            { return await ValidateProduct(name, price, discountprice); }

            Book book = bookwriter.Books.FirstOrDefault(b => b.Id == bId);

            book.Name = name;
            book.Price = price;
            book.DiscountPrice = discountprice;

            Console.ForegroundColor = ConsoleColor.Green;
            return "Book is succesfully updated";
        }

        private async Task<string> ValidateProduct(string name, double price, double discountprice)
        {

            while (string.IsNullOrWhiteSpace(name))
            { return "Please, add valid Name"; }

            while (price <= 0)
            { return "Please, add valid Price"; }

            while (discountprice > price || discountprice <= 0)
            { return "Please, add valid Discountrice"; }

            return null;
        }
    }
}