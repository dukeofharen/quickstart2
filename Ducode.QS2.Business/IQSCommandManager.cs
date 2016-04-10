using Ducode.QS2.Entities;
using System;
using System.Collections.Generic;

namespace Ducode.QS2.Business
{
    public interface IQSCommandManager
    {
        QSCommand[] GetAll();
        QSCommand Get(Guid id);
        void Update(QSCommand command);
        QSCommand Add(QSCommand command);
        bool Delete(Guid id);
    }
}
