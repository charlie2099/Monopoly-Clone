using System.Collections.Generic;

namespace Commands
{
    public class PlayerTurn // Command Invoker
    {
        private readonly Stack<ICommand> _commandsStack = new();

        public void AddCommand(ICommand command) 
        {
            _commandsStack.Push(command);
            command.Execute();
        }

        public void UndoCommand()
        {
            if (_commandsStack.Count > 0)
            {
                ICommand latestCommand = _commandsStack.Pop();
                latestCommand.Undo();
            }
        }
    }
}
