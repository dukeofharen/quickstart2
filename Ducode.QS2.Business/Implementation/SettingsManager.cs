using System;
using Ducode.QS2.Entities;
using Ducode.QS2.Data;
using Ducode.QS2.PortableResources;

namespace Ducode.QS2.Business.Implementation
{
    public class SettingsManager : ISettingsManager
    {
        private readonly ISettingsRepository _settingsRepository;

        public SettingsManager(ISettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        public Setting GetSettings()
        {
            return _settingsRepository.Get();
        }

        public void Update(Setting settings)
        {
            if (settings == null)
            {
                throw new ArgumentException(Strings.SettingsNull);
            }
            _settingsRepository.Update(settings);
        }
    }
}
