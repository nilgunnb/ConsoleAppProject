using CAProject.Core.Enums;
using CAProject.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CAProject.Core.Models.Minor
{
    public class Book : BaseModel
    {
        private static int _id;

        public double Price;

        public double DiscountPrice;
        public BookCategory Category { get; set; }
        public BookWriter Writer { get; set; }

        public Book(string name, double price, double discountprice, BookCategory category, BookWriter writer)
        {
            _id++;
            Id = _id;
            Name = name;
            Price = price;
            DiscountPrice = discountprice;
            Category = category;
            Writer = writer;
        }

        public override string ToString()
        {
            if (DiscountPrice < Price)
            {
                return $"There is  {DiscountPrice / Price * 100}% discount! Title: {Name}, Price: {DiscountPrice}, Genre: {Category}, Author: {Writer}";
            }

            return $"Title: {Name}, Price: {Price}, Genre: {Category}, Author: {Writer}";
        }
    }
}
