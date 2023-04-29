using CAProject.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CAProject.Core.Models.Minor
{
    public class BookWriter : BaseModel
    {
        private static int _id;

        public string Surname;

        public int Age;

        public List<Book> Books;

        public BookWriter(string name, string surname, int age)
        {
            _id++;
            Id = _id;
            Name = name;
            Surname = surname;
            Age = age;
            Books = new List<Book>();
            CreatedDate = DateTime.UtcNow.AddHours(4);
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Surname: {Surname}, Age: {Age}, CreateDate: {CreatedDate}, UpdatedDate: {UpdatedDate}";
        }
    }
}
