using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Repositories.Interfaces
{
    public interface IReminderRepository
    {
        IEnumerable<reminder> FindAll();
        reminder FindOne(int id);
        void Add(reminder reminder);
        void Update(reminder reminder, int id);
        void Delete(int id);
        void DeleteMany(List<int> ids);
        IEnumerable<reminder> FindAllByAppointmentId(int appointmentId);

    }
}
