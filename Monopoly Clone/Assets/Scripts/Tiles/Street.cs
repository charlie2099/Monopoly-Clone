using Interfaces;
using TMPro;
using UnityEngine;

namespace Tiles
{
    public class Street : Tile, IPurchaseable
    {
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
            Debug.Log("Landed on: " + TileName);
        }

        public void Buy()
        {
            // player.Buy(property);
            // player.Sell(property);
            // player.Mortgage(property);
            
            // Player
            // {
            //    List<Properties> ownedProperties;
            //    List<IPurchaseable> ownedProperties;
            // }
        }

        public void Sell()
        {
            
        }

        public void Mortgage()
        {
            
        }
    }
}
