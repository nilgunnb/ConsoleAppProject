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
        public async Task<string> CreateAsync(int id, string name, double price, double discountprice, BookCategory category, bool instock)
        {
            BookWriter bookwriter = await _repository.GetAsync(w => w.Id == id);

            Book book = new Book(name, price, discountprice, category, bookwriter,instock);

            bookwriter.Books.Add(book);

            Console.ForegroundColor = ConsoleColor.Green;
            return "Book is succesfully created!";
        }

        public async Task<string> DeleteAsync(int wId, int bId)
        {
            BookWriter bookwriter = await _repository.GetAsync(w => w.Id == wId);

            Console.ForegroundColor = ConsoleColor.Red;

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
            Console.ForegroundColor = ConsoleColor.Yellow;

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

        public async Task<string> UpdateAsync(int wId, int bId, string name, double price, double discountprice, bool instock)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            BookWriter bookwriter = await _repository.GetAsync(w => w.Id == wId);

            if (bookwriter == null)
            { return "Author is not found"; }

            Book book = bookwriter.Books.FirstOrDefault(b => b.Id == bId);

            book.Name = name;
            book.Price = price;
            book.DiscountPrice = discountprice;
            book.inStock = instock;
            book.UpdatedDate = DateTime.UtcNow.AddHours(4);

            Console.ForegroundColor = ConsoleColor.Green;
            return "Book is succesfully updated!";
        }

        public async Task<string> BuyBookAsync(int wId, int bId)
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

            if (book.inStock == false)
            {
                return "Book is not in stock. You can't buy it";
            }
           
                Console.ForegroundColor = ConsoleColor.Green;
                return "Book is in stock. You can buy it!";
            
        }
    }
}
      