namespace Commands
{
    public class RollDiceCommand : ICommand
    {
        private DiceRoller _diceRoller;

        public RollDiceCommand(DiceRoller diceRoller)
        {
            _diceRoller = diceRoller;
        }

        public void Execute()
        {
            _diceRoller.Throw();
        }

        public void Undo() {}
    }
}