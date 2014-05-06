using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModulPertarungan
{
    public class Invoker
    {   
        private readonly Queue<Command> _commandList = new Queue<Command>();
        public void RunCommand()
        {
            while (_commandList.Count > 0)
            {
                _commandList.Peek().Initialization();
                _commandList.Dequeue().Execute();
            }
        }

        public void AddCommand(Command command)
        {
            _commandList.Enqueue(command);
        }
    }
}
