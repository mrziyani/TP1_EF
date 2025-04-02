using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_EF.Repositories
{
    public interface IReadOnlyRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        
    }

}
