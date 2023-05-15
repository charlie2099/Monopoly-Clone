using UnityEngine;

namespace Tiles
{
    public class Go : Tile
    {
        [SerializeField] private int passingGoReward = 500;
        
        public override void OnLanded(Player player)
        {
            base.OnLanded(player);
            //player.BankAccount.Deposit(passingGoReward);
        }
    }
}