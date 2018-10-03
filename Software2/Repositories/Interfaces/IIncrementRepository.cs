using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Repositories.Interfaces
{
    public interface  IIncrementRepository
    {
        IEnumerable<incrementtype> FindAll();
        incrementtype FindOne(int id);
        int Add(incrementtype incrementType);
        void Update(incrementtype incrementType, int id);
        void Delete(int id);
    }
}
