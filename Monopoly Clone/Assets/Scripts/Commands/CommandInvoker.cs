using System.Collections.Generic;

public class CommandInvoker
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
