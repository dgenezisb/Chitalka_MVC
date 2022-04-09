using Prr_stakan.Data.interfaces;
using Prr_stakan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prr_stakan.Data.mocks
{
    public class MockYears : IBookYears
    {
        
        public IEnumerable<years> AllYaers
        {
            get
            {
                return new List<years>
                {
                    new years
                    {
                       year = 1900,
                       
                    },
                    new years
                    {
                       year = 1910,
                    },
                    new years
                    {
                       year = 1920,
                    },
                    new years
                    {
                       year = 1930,
                    },
                    new years
                    {
                       year = 1940,
                    },

                };
            }
        }
    }
}

