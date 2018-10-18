using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Repositories.Interfaces
{
    public interface IAppointmentRepository
    {
        appointment FindOne(int id);
        IEnumerable<appointment> FindAll();
        void Update(appointment appointment, int id);
        int Add(appointment appointment);
        void Delete(int id);
    }
}
