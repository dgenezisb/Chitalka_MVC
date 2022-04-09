using Prr_stakan.Data.interfaces;
using Prr_stakan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prr_stakan.Data.mocks
{
    public class MockBooks : IAllBooks
    {
        private readonly IBooksCats _categotyBooks = new MockCategory();
        public IEnumerable<books> booksRet {
            get
            {
                return new List<books>
                { new books
                    {
                        bookName = "1984",
                        id = 1,
                        descriprionBook = "если ты ее не знаешь,то ты лох",
                        img = "ass.jpg",
                        Category = _categotyBooks.AllCats.First()
                    },
                    new books
                    {
                        bookName = "vlfff",
                        id = 2,
                        descriprionBook = "если ты ее не знаешь,то ты лох",
                        img = "ass.jpg",
                        Category = _categotyBooks.AllCats.ElementAt(1)
                    },
                    new books
                    {
                        bookName = "12333",
                        id = 3,
                        descriprionBook = "если ты ее не знаешь,то ты лох",
                        img = "ass.jpg",
                        Category = _categotyBooks.AllCats.ElementAt(2)
                    },
                      new books
                    {
                        bookName = "кккккккк",
                        id = 4,
                        descriprionBook = "если ты ее не знаешь,то ты лох",
                        img = "ass.jpg",
                        Category = _categotyBooks.AllCats.ElementAt(4)
                    },
                       new books
                    {
                        bookName = "DEBUG",
                        id = 5,
                        descriprionBook = "если ты ее не знаешь,то ты лох",
                        img = "ass.jpg",
                        Category = _categotyBooks.AllCats.ElementAt(4),
                        bookInside = "text"
                    },
                        new books
                    {
                        bookName = "кккккккк",
                        id = 6,
                        descriprionBook = "если ты ее не знаешь,то ты лох",
                        img = "ass.jpg",
                        Category = _categotyBooks.AllCats.ElementAt(5)
                    }
                };
            }
        }

        public books getObjectBook(int bookID)
        {
            throw new NotImplementedException();
        }
    }
}
