using System;
using UnityEngine;

namespace Tiles
{
    public class Tax : Tile
    {
        public event Action<Tile, int> OnTaxTileLanded;
        
        [SerializeField] private int tax = 250;
        
        public override void OnLanded(Player player)
        {
            player.BankAccount.Withdraw(tax);
            OnTaxTileLanded?.Invoke(this, tax);
        }
    
        /*public void ChargeTax(int tax, Player player)
        {
            player.BankAccount.Withdraw(tax);
        }*/
    }
}
