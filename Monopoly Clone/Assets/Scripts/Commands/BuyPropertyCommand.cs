using Interfaces;

namespace Commands
{
    public class BuyPropertyCommand : ICommand
    {
        private Player _player;
        private IPurchasable _property;
        
        public BuyPropertyCommand(Player player, IPurchasable property)
        {
            _player = player;
            _property = property;
        }
    
        public void Execute()
        {
            _player.BuyProperty(_property);
        }

        public void Undo() {}
    }
}
