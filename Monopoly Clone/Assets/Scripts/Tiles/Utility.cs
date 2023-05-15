using Interfaces;
using TMPro;
using UnityEngine;

namespace Tiles
{
    public class Utility : Tile, IPurchasable
    {
        [SerializeField] private TMP_Text utilityCostText;
        [SerializeField] private int purchaseCost = 250;
        [SerializeField] private int landingCost = 150;
        private Player _owner;

        protected override void Start()
        {
            base.Start();
            utilityCostText.text = $"£{purchaseCost.ToString()}";
        }

        public override void OnLanded(Player player)
        {
            base.OnLanded(player);
            
            if (_owner != null)
            {
                if (player != _owner)
                {
                    player.BankAccount.Pay(_owner.BankAccount, landingCost);
                }
            }
        }

        public void Purchase()
        {
            Debug.Log("Utility purchased");
            _owner.BankAccount.Withdraw(purchaseCost);
        }

        public void Mortgage() {}

        public void SetOwner(Player player)
        {
            _owner = player;
        }

        public Player HasOwner()
        {
            return _owner;
        }
    }
}