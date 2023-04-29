using CAProject.Core.Models.Minor;
using CAProject.Data.Repositories.BookWriters;
using CAProject.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CAProject.Service.Services.Implementations
{
    public class BookWriterService : IBookWriterService
    {
        private readonly BookWriterRepository _repository = new BookWriterRepository();

        public async Task<string> CreateAsync(string name, string surname, int age)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            while (string.IsNullOrWhiteSpace(name))
            { return "Please, add valid Name"; }

            while (string.IsNullOrWhiteSpace(surname))
            { return "Please, add valid Surname"; }

            while (age <= 0 || age > 160)
            { return "Please, add valid age"; }

            Console.ForegroundColor = ConsoleColor.Green;

            BookWriter bookwriter = new BookWriter(name, surname, age);

            await _repository.AddAsync(bookwriter);

            return "Author is uccessfully created!";
        }

        public async Task<string> DeleteAsync(int id)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            BookWriter bookwriter = await _repository.GetAsync(w => w.Id == id);

            if (bookwriter == null)
            { return "restaurant not found"; }

            await _repository.RemoveAsync(bookwriter);

            Console.ForegroundColor = ConsoleColor.Green;

            return "Author is succesfully deleted!";
        }
        public async Task GetAllAsync()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var item in await _repository.GetAllAsync())
            {
                Console.WriteLine(item);
            }
        }

        public async Task<List<Book>> GetAllBooksAsync(int id)
        {
            BookWriter bookwriter = await _repository.GetAsync(w => w.Id == id);

            if (bookwriter == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Author is not found");
                return null;
            }

            return bookwriter.Books;
        }

        public async Task<BookWriter> GetAsync(int id)
        {
            BookWriter bookwriter = await _repository.GetAsync(w => w.Id == id);

            if (bookwriter == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Author is not found");
                return null;
            }
            return bookwriter;
        }
        public async Task<string> UpdateAsync(int id, string name, string surname, int age)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            while (string.IsNullOrWhiteSpace(name))
            { return "Please, add valid Name"; }

            while (string.IsNullOrWhiteSpace(surname))
            { return "Please, add valid Surname"; }

            while (age <= 0 || age > 160)
            { return "Please, add valid Age"; }

            BookWriter bookwriter = await _repository.GetAsync(w => w.Id == id);

            if (bookwriter == null)
            { return "Author is not found"; }

            bookwriter.Name = name;

            bookwriter.Surname = surname;

            bookwriter.Age = age;

            Console.ForegroundColor = ConsoleColor.Green;

            return "Author is succesfully updated!";
        }

    }
}