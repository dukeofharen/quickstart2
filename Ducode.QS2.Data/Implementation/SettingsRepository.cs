using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ducode.QS2.Entities;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Ducode.QS2.PortableResources;

namespace Ducode.QS2.Data.Implementation
{
    public class SettingsRepository : ISettingsRepository
    {
        private string _jsonLocation = Vars.SettingsJsonFileName;

        public Setting Get()
        {
            Setting setting = null;
            if (!File.Exists(_jsonLocation))
            {
                setting = new Setting()
                {
                    ItemsFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                };
                Update(setting);
            }
            else
            {
                string contents = File.ReadAllText(_jsonLocation);
                setting = JsonConvert.DeserializeObject<Setting>(contents);
            }
            return setting;
        }

        public void Update(Setting setting)
        {
            File.WriteAllText(_jsonLocation, JsonConvert.SerializeObject(setting));
        }
    }
}
