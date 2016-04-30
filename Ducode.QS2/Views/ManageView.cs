using Ducode.QS2.Business;
using Ducode.QS2.Entities;
using Ducode.QS2.PortableResources;
using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace Ducode.QS2.Views
{
    public partial class ManageView : Form
    {
        private readonly ISettingsManager _settingsManager;
        private readonly IQSCommandManager _qsCommandManager;
        private readonly ICommandRunner _commandRunner;
        private readonly TableLayoutPanel _table;
        private int _y = 0;
        private const int _rowHeight = 28;

        public MainForm MainForm { get; set; }

        public ManageView(ISettingsManager settingsManager, IQSCommandManager qsCommandManager, ICommandRunner commandRunner)
        {
            _settingsManager = settingsManager;
            _qsCommandManager = qsCommandManager;
            _commandRunner = commandRunner;
            _table = new TableLayoutPanel();

            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            InitializeTable();
            Text = Strings.ManageFormTitle;
            titleLabel.Text = Strings.Commands;
            selectFolderButton.Text = Strings.SelectItemsFolder;
            addCommandButton.Text = Strings.AddCommand;
            saveButton.Text = Strings.Save;
            managePanel.Controls.Add(_table);

            var settings = _settingsManager.GetSettings();
            itemsFolderLocation.Text = settings.ItemsFolder;
            selectFolderButton.Click += new EventHandler((object sender, EventArgs args) =>
            {
                var dialog = new FolderBrowserDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    itemsFolderLocation.Text = dialog.SelectedPath;
                    settings.ItemsFolder = dialog.SelectedPath;
                    _settingsManager.Update(settings);
                    InitializeTable();
                    MainForm.RefreshItems();
                }
            });
        }

        private void InitializeTable()
        {
            ClearTable();

            var commands = _qsCommandManager.GetAll();

            int newTableHeight = 50;

            _table.Width = managePanel.Width - 50;
            _table.RowCount = 0;

            _y = 0;

            _table.Controls.Add(new Label()
            {
                Text = Strings.Name
            }, 0, _y);
            _table.Controls.Add(new Label()
            {
                Text = Strings.Command
            }, 1, _y);
            _table.Controls.Add(new Label()
            {
                Text = Strings.Actions
            }, 2, _y);

            _y++;
            _table.Height += _rowHeight;
            _table.RowCount++;

            foreach (var command in commands)
            {
                AddRow(command);
                newTableHeight += _rowHeight;
            }
            _table.Height = newTableHeight;
        }

        private void ClearTable()
        {
            _table.RowStyles.Clear();
            _table.Controls.Clear();
        }

        private void DeleteCommand(QSCommand command)
        {
            if (MessageBox.Show(Strings.AreYouSure, Strings.Delete, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _qsCommandManager.Delete(command.ID);
                InitializeTable();
                MainForm.RefreshItems();
            }
        }

        private void AddRow()
        {
            AddRow(new QSCommand()
            {
                ID = Guid.NewGuid()
            });
        }

        private void AddRow(QSCommand command)
        {
            _table.Controls.Add(new TextBox()
            {
                Text = command.Name,
                Width = 200,
                Tag = command
            }, 0, _y);

            _table.Controls.Add(new TextBox()
            {
                Text = command.Command,
                Width = 200,
                Tag = string.Format("command-{0}", _y)
            }, 1, _y);

            var commandTestButton = new Button()
            {
                Text = Strings.Test,
                Tag = _y
            };
            commandTestButton.Click += new EventHandler((sender, args) =>
            {
				var control = _table.Controls
									 .OfType<TextBox>()
									 .Where(c => c.Tag.ToString() == string.Format("command-{0}", ((Button)sender).Tag))
									 .FirstOrDefault();
				string commandText = control == null ? string.Empty : control.Text;
                _commandRunner.RunCommand(commandText);
            });
            _table.Controls.Add(commandTestButton, 2, _y);

            var deleteButton = new Button()
            {
                Text = Strings.Delete,
                Tag = command
            };
            deleteButton.Click += new EventHandler((sender, args) =>
            {
                DeleteCommand((QSCommand)((Button)sender).Tag);
            });
            _table.Controls.Add(deleteButton, 3, _y);

            _y++;
            _table.RowCount++;
        }

        private void addCommandButton_Click(object sender, EventArgs e)
        {
            AddRow();
            _table.Height += _rowHeight;
            //managePanel.ScrollToBottom();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            for (int row = 0; row < _table.RowCount; row++)
            {
                var control1 = _table.GetControlFromPosition(0, row);
                var control2 = _table.GetControlFromPosition(1, row);
                if(control1 is TextBox && control2 is TextBox)
                {
                    if (!string.IsNullOrEmpty(control1.Text) && !string.IsNullOrEmpty(control2.Text))
                    {
                        var command = (QSCommand)control1.Tag;
                        command.Name = control1.Text;
                        command.Command = control2.Text;
                        if (_qsCommandManager.Get(command.ID) == null)
                        {
                            _qsCommandManager.Add(command);
                        }
                        else
                        {
                            _qsCommandManager.Update(command);
                        }
                    }
                }
            }
            MainForm.RefreshItems();
            Close();
        }
    }
}