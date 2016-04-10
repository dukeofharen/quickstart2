using Ducode.QS2.PortableResources;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Ducode.QS2.Business.Implementation
{
    public class CommandRunner : ICommandRunner
    {
        private ISettingsManager _settingsManager;

        public CommandRunner(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }

        public void RunCommand(string command)
        {
            StringBuilder builder = new StringBuilder();

            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = Vars.ProcessExeFileName;

            string path = Path.GetFullPath(_settingsManager.GetSettings().ItemsFolder);
            string root = Path.GetPathRoot(path);
            root = !string.IsNullOrEmpty(root) ? string.Format("&& {0} ", root).Replace("\\", string.Empty) : string.Empty;

            startInfo.Arguments = string.Format(Vars.CommandFormat, root, path, command);
            startInfo.UseShellExecute = false;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }
    }
}
