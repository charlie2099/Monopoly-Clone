namespace Tiles
{
    public class Tax : Tile
    {
        public void ChargeTax(int tax, Player player)
        {
            player.BankAccount.Withdraw(tax);
        }
    }
}