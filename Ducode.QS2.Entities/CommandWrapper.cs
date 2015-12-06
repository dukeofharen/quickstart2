using System.Collections.Generic;

namespace Ducode.QS2.Entities
{
    public class CommandWrapper
    {
        private List<QSCommand> _commands;
        public List<QSCommand> Commands
        {
            get
            {
                if(_commands == null)
                {
                    _commands = new List<QSCommand>();
                }
                return _commands;
            }
            set
            {
                _commands = value;
            }
        }
    }
}
