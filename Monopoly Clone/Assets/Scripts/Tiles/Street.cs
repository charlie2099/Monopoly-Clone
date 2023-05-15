using System;
using Decorators;
using Interfaces;
using ScriptableObjects.PropertyData;
using TMPro;
using UnityEngine;

namespace Tiles
{
    public class Street : Tile, IProperty
    {
        public PropertyData PropertyData => _decorableProperty.PropertyData;

        [Header("Property Data")]
        [SerializeField] private TextMeshPro streetCostText;
        [SerializeField] private MeshRenderer streetColourBar;
        [SerializeField] private PropertyData propertyData;
        private IProperty _decorableProperty;
        private Player _owner;

        protected override void Start()
        {
            base.Start();
            streetCostText.text = $"£{propertyData.purchaseData.purchaseCost.ToString()}";
            streetColourBar.material.color = propertyData.colourBlock.colour;
        }

        public override void OnLanded(Player player)
        {
            base.OnLanded(player);
            
            if (_owner != null)
            {
                if (player != _owner)
                {
                    Debug.Log($"{player.Username} paid {propertyData.rentData.GetRentLevel(RentLevel.NoHouses)} to {_owner.Username}");
                    player.BankAccount.Pay(_owner.BankAccount, propertyData.rentData.GetRentLevel(RentLevel.NoHouses));
                }
            }
        }

        public void Purchase()
        {
            Debug.Log("Street purchased");
            _owner.BankAccount.Withdraw(propertyData.purchaseData.purchaseCost);
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

        [ContextMenu("Upgrade Property")]
        public void Upgrade()
        {
            _decorableProperty = new HouseDecorator(_decorableProperty);
            _decorableProperty.Upgrade();
        }

        public void Downgrade() {}
    }
}
