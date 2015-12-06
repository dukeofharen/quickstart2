using Ducode.QS2.Entities;

namespace Ducode.QS2.Business
{
    public interface ISettingsManager
    {
        Setting GetSettings();
        void Update(Setting settings);
    }
}
