using System;
using Interfaces;
using TMPro;
using UnityEngine;

namespace Tiles
{
    public class Street : Tile, IPurchasable
    {
        public event Action<Tile> OnPropertyTileLanded;
        public Player Owner { get; set; }
        public int Cost { get; set; }

        [Header("Street Data")]
        [SerializeField] private ColourBlock colourBlock;
        [SerializeField] private TextMeshPro streetCostText;
        [SerializeField] private MeshRenderer streetColourBar;

        protected override void Start()
        {
            base.Start();
            streetCostText.text = "£1Mil";
            streetColourBar.material.color = colourBlock.blockColour;
        }

        public override void OnLanded()
        {
            OnPropertyTileLanded?.Invoke(this);
        }

        public void Purchase()
        {
            Debug.Log("Property purchased");
            Owner = GameManager.Instance.ActivePlayer;
            Owner.Money -= Cost;
        }

        public void Mortgage() {}
    }
}
