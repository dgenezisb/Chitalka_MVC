using Prr_stakan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prr_stakan.Data.interfaces
{
    //берет все категории проекта
    public interface IBooksCats
    {
        IEnumerable<category> AllCats { get; }
    }
}
