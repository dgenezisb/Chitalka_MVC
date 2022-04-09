using Prr_stakan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prr_stakan.Data.interfaces
{
    public interface IBookYears
    {
        IEnumerable<years> AllYaers { get; }
    }
}
