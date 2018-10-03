using Software2.Models.Exceptions;
using Software2.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Services
{
    public class IncrementService
    {
        private IIncrementRepository _repository;

        public IncrementService(IIncrementRepository repository)
        {
            _repository = repository;
        }

        public incrementtype FindOne(int id)
        {
            var incrementToReturn = _repository.FindOne(id);
            if (incrementToReturn == null)
                throw new NotFoundException("Could not locate increment type with specified ID");
            return incrementToReturn;
        }

        public IEnumerable<incrementtype> FindAll()
        {
            return _repository.FindAll()?.ToList();
        }

        public int Add(incrementtype incrementType)
        {
            Validate(incrementType);
            return _repository.Add(incrementType);
        }

        public void Update(incrementtype incrementType, int id)
        {
            Validate(incrementType);
            FindOne(id);
            _repository.Update(incrementType, id);
        }

        public void Delete(int id)
        {
            FindOne(id);
            _repository.Delete(id);
        }

        private void Validate(incrementtype incrementType)
        {
            if (String.IsNullOrEmpty(incrementType.incrementTypeDescription))
                throw new InvalidInputException("Increment description is required.");

        }
    }
}
