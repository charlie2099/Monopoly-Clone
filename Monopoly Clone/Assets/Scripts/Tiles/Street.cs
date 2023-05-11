using System;
using Interfaces;
using TMPro;
using UnityEngine;

namespace Tiles
{
    public class Street : Tile, IPurchasable
    {
        public event Action<Tile> OnPropertyTileLanded;
        public int PropertyCost { get; set; }

        [Header("Street Data")]
        [SerializeField] private ColourBlock colourBlock;
        [SerializeField] private TextMeshPro streetCostText;
        [SerializeField] private MeshRenderer streetColourBar;
        
        private Player _owner;

        protected override void Start()
        {
            base.Start();
            streetCostText.text = "£1Mil";
            streetColourBar.material.color = colourBlock.blockColour;
            PropertyCost = 25;
        }

        public override void OnLanded()
        {
            OnPropertyTileLanded?.Invoke(this);
        }

        public void Purchase()
        {
            Debug.Log("Property purchased");
            _owner.Balance -= PropertyCost;
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
