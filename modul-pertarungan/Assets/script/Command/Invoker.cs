using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModulPertarungan
{
    public class Invoker
    {   
        private Queue<Command> commandList = new Queue<Command>();
        public void RunCommand()
        {
            while (commandList.Count > 0)
            {
                commandList.Peek().Initialization();
                commandList.Dequeue().Execute();
            }
        }

        public void AddCommand(Command command)
        {
            commandList.Enqueue(command);
        }
    }
}
