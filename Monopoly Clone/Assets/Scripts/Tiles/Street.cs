using System;
using Interfaces;
using ScriptableObjects;
using TMPro;
using UnityEngine;

namespace Tiles
{
    public class Street : Tile, IPurchasable
    {
        public event Action<Tile> OnPropertyTileLanded;
        public PropertyData PropertyData => propertyData;

        [Header("Property Data")]
        [SerializeField] private TextMeshPro streetCostText;
        [SerializeField] private MeshRenderer streetColourBar;
        [SerializeField] private PropertyData propertyData;
        private Player _owner;

        protected override void Start()
        {
            base.Start();
            streetCostText.text = propertyData.purchaseData.purchaseCost.ToString();
            streetColourBar.material.color = propertyData.colourBlock.colour;
        }

        public override void OnLanded(Player player)
        {
            if (player != _owner && _owner != null)
            {
                player.Balance -= propertyData.rentData.rentWithNoHouses;
            }
            
            OnPropertyTileLanded?.Invoke(this);
        }

        public void Purchase()
        {
            Debug.Log("Property purchased");
            _owner.Balance -= propertyData.purchaseData.purchaseCost;
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
