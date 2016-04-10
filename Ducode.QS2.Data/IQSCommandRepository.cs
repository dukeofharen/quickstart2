using Ducode.QS2.Entities;
using System;

namespace Ducode.QS2.Data
{
    public interface IQSCommandRepository
    {
        QSCommand[] GetAll();
        QSCommand Get(Guid id);
        void Update(QSCommand command);
        QSCommand Add(QSCommand command);
        bool Delete(Guid id);
    }
}
