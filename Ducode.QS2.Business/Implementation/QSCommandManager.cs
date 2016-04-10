using System;
using Ducode.QS2.Entities;
using Ducode.QS2.Data;
using Ducode.QS2.PortableResources;

namespace Ducode.QS2.Business.Implementation
{
    public class QSCommandManager : IQSCommandManager
    {
        private readonly IQSCommandRepository _qsCommandRepository;

        public QSCommandManager(IQSCommandRepository qsCommandRepository)
        {
            _qsCommandRepository = qsCommandRepository;
        }

        public QSCommand Add(QSCommand command)
        {
            if (command == null)
            {
                throw new ArgumentException(Strings.CommandNull);
            }
            return _qsCommandRepository.Add(command);
        }

        public bool Delete(Guid id)
        {
            return _qsCommandRepository.Delete(id);
        }

        public QSCommand Get(Guid id)
        {
            return _qsCommandRepository.Get(id);
        }

        public QSCommand[] GetAll()
        {
            return _qsCommandRepository.GetAll();
        }

        public void Update(QSCommand command)
        {
            if (command == null)
            {
                throw new ArgumentException(Strings.CommandNull);
            }
            _qsCommandRepository.Update(command);
        }
    }
}
