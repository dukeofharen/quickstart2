using System;
using System.Linq;
using Ducode.QS2.Entities;
using System.IO;
using Newtonsoft.Json;
using Ducode.QS2.PortableResources;

namespace Ducode.QS2.Data.Implementation
{
    public class QSCommandRepository : IQSCommandRepository
    {
        private readonly ISettingsRepository _settingsRepository;

        private string _fileName = Vars.ItemsJsonFileName;

        public QSCommandRepository(ISettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        public QSCommand Add(QSCommand command)
        {
            AssertCommandsFileExists();
            command.ID = Guid.NewGuid();
            var wrapper = GetCommandWrapper();
            wrapper.Commands.Add(command);
            UpdateCommandWrapper(wrapper);
            return command;
        }

        public bool Delete(Guid id)
        {
            AssertCommandsFileExists();
            string path = GetFilePath();
            var wrapper = GetCommandWrapper();
            var command = wrapper.Commands.Where(c => c.ID == id).FirstOrDefault();
            if(command == null)
            {
                return false;
            }
            wrapper.Commands.Remove(command);
            UpdateCommandWrapper(wrapper);
            return true;
        }

        public QSCommand Get(Guid id)
        {
            AssertCommandsFileExists();
            var wrapper = GetCommandWrapper();
            return wrapper.Commands.Where(c => c.ID == id).FirstOrDefault();
        }

        public QSCommand[] GetAll()
        {
            AssertCommandsFileExists();
            var wrapper = GetCommandWrapper();
            return wrapper.Commands.OrderBy(c => c.Name).ToArray();
        }

        public void Update(QSCommand command)
        { 
            AssertCommandsFileExists();
            var wrapper = GetCommandWrapper();
            var existingCommand = wrapper.Commands.Where(c => c.ID == command.ID).FirstOrDefault();
            if (existingCommand == null)
            {
                throw new ArgumentException(string.Format(Strings.CommandDoesntExist, command.ID));
            }
            int index = wrapper.Commands.IndexOf(existingCommand);
            wrapper.Commands[index] = command;
            UpdateCommandWrapper(wrapper);
        }

        private void AssertCommandsFileExists()
        {
            var settings = _settingsRepository.Get();
            if (settings == null)
            {
                throw new ArgumentException(Strings.SettingsFileDoesntExist);
            }
            if (!Directory.Exists(settings.ItemsFolder))
            {
                throw new ArgumentException(string.Format(Strings.ItemsFolderDoesntExist, settings.ItemsFolder));
            }
            string filePath = GetFilePath();
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, JsonConvert.SerializeObject(new CommandWrapper()));
            }
        }

        #region Private methods
        private string GetFilePath()
        {
            var settings = _settingsRepository.Get();
            return Path.Combine(settings.ItemsFolder, _fileName);
        }

        private CommandWrapper GetCommandWrapper()
        {
            return JsonConvert.DeserializeObject<CommandWrapper>(File.ReadAllText(GetFilePath()));
        }

        private void UpdateCommandWrapper(CommandWrapper wrapper)
        {
            File.WriteAllText(GetFilePath(), JsonConvert.SerializeObject(wrapper));
        }
        #endregion
    }
}
