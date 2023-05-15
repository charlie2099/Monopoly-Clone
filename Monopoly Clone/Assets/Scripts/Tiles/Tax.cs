using System;
using TMPro;
using UnityEngine;

namespace Tiles
{
    public class Tax : Tile
    {
        public event Action<Tile, int> OnTaxTileLanded;
        
        [SerializeField] private TMP_Text taxOwedText;
        [SerializeField] private int tax = 250;
        
        protected override void Start()
        {
            base.Start();
            taxOwedText.text = $"Pay £{tax.ToString()}";
        }

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
