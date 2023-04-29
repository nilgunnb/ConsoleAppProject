using CAProject.Core.IRepositories.BookWriterRepo;
using CAProject.Core.Models.Minor;
using CAProject.Data.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAProject.Data.Repositories.BookWriters
{
    public class BookWriterRepository : Repository<BookWriter>, IBookWriterRepository
    {
    }
}
