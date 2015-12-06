using Ducode.QS2.Business;
using Ducode.QS2.Business.Implementation;
using Ducode.QS2.Data;
using Ducode.QS2.Data.Implementation;
using Ducode.QS2.Views;
using Microsoft.Practices.Unity;

namespace Ducode.QS2.Unity
{
    public static class UnityConfig
    {
        public static void Configure()
        {
            var container = new UnityContainer();

            Container.Initialize(container);

            container.RegisterType<MainForm>();
            container.RegisterType<ManageView>();

            container.RegisterType<ISettingsRepository, SettingsRepository>();
            container.RegisterType<IQSCommandRepository, QSCommandRepository>();
            container.RegisterType<ICommandRunner, CommandRunner>();

            container.RegisterType<ISettingsManager, SettingsManager>();
            container.RegisterType<IQSCommandManager, QSCommandManager>();
        }
    }
}
