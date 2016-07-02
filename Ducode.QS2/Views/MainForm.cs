using Ducode.QS2.Business;
using Ducode.QS2.Entities;
using System;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using Ducode.QS2.PortableResources;
using System.Drawing;
using System.Reflection;
using System.Linq;

namespace Ducode.QS2.Views
{
    public partial class MainForm : Form
    {
        private readonly IQSCommandManager _qsCommandManager;
        private readonly ICommandRunner _commandRunner;

        public MainForm(IQSCommandManager qsCommandManager, ICommandRunner commandRunner)
        {
            _qsCommandManager = qsCommandManager;
            _commandRunner = commandRunner;

            InitializeComponent();
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(false);
        }

        public void RefreshItems()
        {
            InitMenu();
        }

        #region Private methods
        private void InitMenu()
        {
            trayIon.Text = Strings.TrayIconToolTipText;
            trayIconMenu.Items.Clear();
            var commands = _qsCommandManager.GetAll();
            var folders = commands.Select(c => c.Folder)
                                  .Where(f => !string.IsNullOrEmpty(f))
                                  .Select(f => new ToolStripMenuItem()
                                  {
                                      Text = f
                                  })
                                  .OrderBy(i => i.Text)
                                  .ToList();
            foreach(var folder in folders)
            {
                trayIconMenu.Items.Add(folder);
            }
            foreach (var command in commands)
            {
                var menuItem = new ToolStripMenuItem()
                {
                    Text = command.Name,
                    Tag = command
                };
                menuItem.Click += new EventHandler((object sender, EventArgs args) =>
                {
                    var clickedCommand = (QSCommand)((ToolStripMenuItem)sender).Tag;
                    if (clickedCommand != null)
                    {
                        _commandRunner.RunCommand(clickedCommand.Command);
                    }
                });

                var folder = folders.FirstOrDefault(f => f.Text == command.Folder);
                if (folder != null)
                {
                    folder.DropDownItems.Add(menuItem);
                }
                else
                {
                    trayIconMenu.Items.Add(menuItem);
                }
            }

            trayIconMenu.Items.Add(new ToolStripSeparator());

            var manageItem = new ToolStripMenuItem()
            {
                Text = Strings.Manage
            };
            manageItem.Click += new EventHandler((object sender, EventArgs args) =>
            {
                Manage();
            });
            trayIconMenu.Items.Add(manageItem);

            var aboutItem = new ToolStripMenuItem()
            {
                Text = Strings.About
            };
            aboutItem.Click += new EventHandler((object sender, EventArgs args) =>
            {
                About();
            });
            trayIconMenu.Items.Add(aboutItem);

            var exitItem = new ToolStripMenuItem()
            {
                Text = Strings.Exit
            };
            exitItem.Click += new EventHandler((object sender, EventArgs args) =>
            {
                Exit();
            });
            trayIconMenu.Items.Add(exitItem);
        }

        private void Manage()
        {
            var manageView = Unity.Container.Current.Resolve<ManageView>();
            manageView.MainForm = this;
            manageView.Show();
        }

        private void About()
        {
            string text = string.Format(Strings.AboutText, Assembly.GetExecutingAssembly().GetName().Version);
            MessageBox.Show(text, Strings.About);
        }

        private void Exit()
        {
            Application.Exit();
        }

        private void trayIon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Manage();
        }
        #endregion
    }
}