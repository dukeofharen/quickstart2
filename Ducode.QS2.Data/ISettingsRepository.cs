using Ducode.QS2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ducode.QS2.Data
{
    public interface ISettingsRepository
    {
        Setting Get();
        void Update(Setting setting);
    }
}
