﻿using CAProject.Core.Models.Minor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CAProject.Service.Services.Interfaces
{
    public interface IBookWriterService
    {
        public Task<string> CreateAsync(string name, string surname, int age);
        public Task<string> DeleteAsync(int id);
        public Task<string> UpdateAsync(int id, string name, string surname, int age);
        public Task<BookWriter> GetAsync(int id);
        public Task GetAllAsync();
        public Task<List<Book>> GetAllBooksAsync(int id);
    }
}
