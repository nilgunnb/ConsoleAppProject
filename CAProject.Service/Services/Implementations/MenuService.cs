using CAProject.Core.Enums;
using CAProject.Core.Models;
using CAProject.Core.Models.Minor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CAProject.Service.Services.Implementations
{
    public class MenuService
    {
        public bool IsAdmin = false;

        private User[] Users = { new User { UserName = "CodeAcademy", Password = "Code1234!" }, new User { UserName = "Nilgun", Password = "Nilgun1234!" } };



        private BookWriterService bookwriterService = new BookWriterService();
        private BookService bookService = new BookService();

        public async Task<bool> Login()
        {
            Console.WriteLine("Please, enter your username");
            string username = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(username))
            {
                Console.WriteLine("Please, enter valid Username");
                username = Console.ReadLine();
            }
            Console.WriteLine("Please, enter your password");
            string password = Console.ReadLine();

            if (Users.Any(x => x.UserName == username && x.Password == password))
            {
                IsAdmin = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your username or password is incorrect. Please, enter your account details again");
                IsAdmin = false;
            }

            return IsAdmin;
        }

        public async Task ShowMenuAdmin()
        {
            Console.ForegroundColor = ConsoleColor.White;

            string sentence = "Welcome to My App!";

            foreach (var item in sentence)
            {
                Thread.Sleep(100);
                Console.Write(item);
            }
            Console.WriteLine(" ");
            Console.WriteLine("0.Close App");
            Console.WriteLine("1.Create Author");
            Console.WriteLine("2.Show Authors");
            Console.WriteLine("3.Show Author by ID");
            Console.WriteLine("4.Show Author's books");
            Console.WriteLine("5.Update Author");
            Console.WriteLine("6.Remove Author");
            Console.WriteLine("7.Create Book");
            Console.WriteLine("8.Update Book");
            Console.WriteLine("9.Get Book by Author");
            Console.WriteLine("10.Remove Book");
            Console.WriteLine("11.Show All Books");
           
            string Request = Console.ReadLine();

            while (Request != "0")
            {
                switch (Request)
                {
                    case "1":
                        Console.Clear();
                        await CreateBookWriter();

                        break;
                    case "2":
                        Console.Clear();

                        await ShowBookWriters();
                        break;

                    case "3":
                        Console.Clear();

                        await ShowBookWriterById();
                        break;

                    case "4":
                        Console.Clear();

                        await ShowBookWriterBooks();
                        break;

                    case "5":
                        Console.Clear();

                        await UpdateBookWriter();
                        break;

                    case "6":
                        Console.Clear();

                        await RemoveBookWriter();
                        break;

                    case "7":
                        Console.Clear();

                        await CreateBook();
                        break;

                    case "8":
                        Console.Clear();

                        await UpdateBook();
                        break;

                    case "9":
                        Console.Clear();

                        await GetBookByBookWriter();
                        break;

                    case "10":
                        Console.Clear();

                        await RemoveBook();
                        break;

                    case "11":
                        Console.Clear();

                        await ShowAllBooks();
                        break;
                    
                    default:
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Select valid option");
                        break;
                }

                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("0.Close App");
                Console.WriteLine("1.Create Author");
                Console.WriteLine("2.Show Authors");
                Console.WriteLine("3.Show Author by ID");
                Console.WriteLine("4.Show Author's books");
                Console.WriteLine("5.Update Author");
                Console.WriteLine("6.Remove Author");
                Console.WriteLine("7.Create Book");
                Console.WriteLine("8.Update Book");
                Console.WriteLine("9.Get Book by Author");
                Console.WriteLine("10.Remove Book");
                Console.WriteLine("11.Show All Books");
               
                Request = Console.ReadLine();
            }
        }

        public async Task ShowMenuUser()
        {
            Console.ForegroundColor = ConsoleColor.White;
            string sentence = "Welcome to My App!";

            foreach (var item in sentence)
            {
                Thread.Sleep(100);
                Console.Write(item);
            }

            Console.WriteLine("0.Close App");
            Console.WriteLine("1.Show Authors");
            Console.WriteLine("2.Show Author by ID");
            Console.WriteLine("3.Show Author's books");
            Console.WriteLine("4.Get Book by Author");
            Console.WriteLine("5.Show All Books");
            Console.WriteLine("6.Buy Book");

            string Request = Console.ReadLine();

            while (Request != "0")
            {
                switch (Request)
                {
                    case "1":
                        Console.Clear();
                        await ShowBookWriters();

                        break;
                    case "2":
                        Console.Clear();
                        await ShowBookWriterById();

                        break;

                    case "3":
                        Console.Clear();

                        await ShowBookWriterBooks();
                        break;

                    case "4":
                        Console.Clear();
                        await ShowBookWriterBooks();
                        break;

                    case "5":
                        Console.Clear();

                        await ShowAllBooks();
                        break;
                        case "6":
                            Console.Clear();

                            await BuyBook();
                            break;
                        default: 
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please, select valid option");
                        break;
                }

                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("0.Close App");
                Console.WriteLine("1.Show Authors");
                Console.WriteLine("2.Show Author by ID");
                Console.WriteLine("3.Show Author's books");
                Console.WriteLine("4.Get Book by Author");
                Console.WriteLine("5.Show All Books");
                Console.WriteLine("6.Buy Book");

                Request = Console.ReadLine();
            }
        }

        private async Task CreateBookWriter()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please, add Name");
            string name = Console.ReadLine();
            Console.WriteLine("Please, add Surname");
            string surname = Console.ReadLine();
            Console.WriteLine("Please, add Age");
            int.TryParse(Console.ReadLine(), out int age);

            string message = await bookwriterService.CreateAsync(name, surname, age);

            Console.WriteLine(message);
        }

        private async Task ShowBookWriters()
        {
            await bookwriterService.GetAllAsync();
        }

        private async Task ShowBookWriterById()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Please, enter Athor's ID");
            int.TryParse(Console.ReadLine(), out int id);

            BookWriter bookwriter = await bookwriterService.GetAsync(id);

            if (bookwriter != null)
            {
                Console.WriteLine(bookwriter);
            }
        }

        private async Task ShowBookWriterBooks()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Please, enter Author's ID");
            int.TryParse(Console.ReadLine(), out int id);

            List<Book> books = await bookwriterService.GetAllBooksAsync(id);

            if (books != null)
            {
                foreach (var item in books)
                {
                    Console.WriteLine(item);
                    Console.WriteLine("----");
                }
            }
        }

        private async Task UpdateBookWriter()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Please, enter Author's ID");
            int.TryParse(Console.ReadLine(), out int id);
            Console.WriteLine("Please, add new Name");
            string name = Console.ReadLine();
            Console.WriteLine("Please, add new Surname");
            string surname = Console.ReadLine();
            Console.WriteLine("Please, add new Age");
            int.TryParse(Console.ReadLine(), out int age);

            string message = await bookwriterService.UpdateAsync(id, name, surname, age);

            Console.WriteLine(message);
        }

        private async Task RemoveBookWriter()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Please, enter Author's ID");
            int.TryParse(Console.ReadLine(), out int id);

            string message = await bookwriterService.DeleteAsync(id);

            Console.WriteLine(message);
        }

        private async Task CreateBook()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please, add Author's ID");
            int.TryParse(Console.ReadLine(), out int id);
            Console.WriteLine("Please, add Title");
            string name = Console.ReadLine();

            Console.WriteLine("Please, add Price");
            int.TryParse(Console.ReadLine(), out int price);

            Console.WriteLine("Please, add Discount Price");
            int.TryParse(Console.ReadLine(), out int discountprice);

            Console.WriteLine("add discount description");
            string description = Console.ReadLine();

            Console.WriteLine("Please, add if it is in stock or not");
            bool.TryParse(Console.ReadLine(), out bool instock);

            BookCategory category;
            Console.WriteLine("Please, choose a Category");
            foreach (var item in Enum.GetValues(typeof(BookCategory)))
            {
                Console.WriteLine((int)item + "." + item);
            }
            int.TryParse(Console.ReadLine(), out int categoryindex);

            var result = Enum.GetName(typeof(BookCategory), categoryindex);

            while (result == null)
            {
                Console.WriteLine("Please, choose valid Category");
                int.TryParse(Console.ReadLine(), out categoryindex);
                result = Enum.GetName(typeof(BookCategory), categoryindex);
            }
            category = (BookCategory)categoryindex;

            string message = await bookService.CreateAsync(id, name, price, discountprice, category, instock);

            Console.WriteLine(message);
        }


        private async Task UpdateBook()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please, enter Author's ID");
            int.TryParse(Console.ReadLine(), out int wId);
            Console.WriteLine("Please, enter Book's id");
            int.TryParse(Console.ReadLine(), out int bId);

            Console.WriteLine("Please, add new Title");
            string name = Console.ReadLine();
                        
            Console.WriteLine("Please, add new Price");
            int.TryParse(Console.ReadLine(), out int price);
                     
            Console.WriteLine("Please, add new Discount Price");
            int.TryParse(Console.ReadLine(), out int discountprice);
                      
            Console.WriteLine("Please, add if book is in stock or not");
            bool.TryParse(Console.ReadLine(), out bool instock);

            string message = await bookService.UpdateAsync(wId, bId, name, price, discountprice, instock);
            Console.WriteLine(message);
                

        }

        private async Task GetBookByBookWriter()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please, add Author's ID");
            int.TryParse(Console.ReadLine(), out int wId);
            Console.WriteLine("Please, add Book's ID");
            int.TryParse(Console.ReadLine(), out int bId);

            Book book = await bookService.GetAsync(wId, bId);

            if (book!= null)
            {
                Console.WriteLine(book);
            }
        }

        private async Task RemoveBook()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please, add Author's ID");
            int.TryParse(Console.ReadLine(), out int wId);
            Console.WriteLine("Please,add Book's ID");
            int.TryParse(Console.ReadLine(), out int bId);

            string message = await bookService.DeleteAsync(wId, bId);

            Console.WriteLine(message);
        }

        private async Task BuyBook()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please, add Author's ID");
            int.TryParse(Console.ReadLine(), out int wId);
            Console.WriteLine("Please, add Book's ID");
            int.TryParse(Console.ReadLine(), out int bId);

            string message = await bookService.BuyBookAsync(wId, bId);

            Console.WriteLine(message);
        }
        private async Task ShowAllBooks()
        {
            await bookService.GetAll();
        }
    }
}
