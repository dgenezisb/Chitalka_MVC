using Prr_stakan.Data.interfaces;
using Prr_stakan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prr_stakan.Data.mocks
{
    public class MockCategory : IBooksCats
    {
        public IEnumerable<category> AllCats
        {
            get
            {
                return new List<category>
                {
                    new category
                    {
                        categoryName = "Фантастика",
                        id = 1,
                        description = "собрание топчика в жанре фантастика"
                    },
                    new category
                    {
                        categoryName = "Ужас",
                        id = 2,
                        description = "собрание топчика в жанре ужас"
                    },
                     new category
                    {
                        categoryName = "Приключения",
                        id = 3,
                        description = "собрание топчика в жанре приключения"
                    },
                      new category
                    {
                        categoryName = "Драма",
                        id = 4,
                        description = "собрание топчика в жанре драма"
                    },
                      new category
                    {
                        categoryName = "Роман",
                        id = 5,
                        description = "собрание топчика в жанре роман"
                    },
                      new category
                    {
                        categoryName = "Эпос",
                        id = 6,
                        description = "собрание топчика в жанре роман"
                    },
                      new category
                    {
                        categoryName = "Эпопея",
                        id = 7,
                        description = "собрание топчика в жанре роман"
                    },
                };
            }
        }
    }
}
