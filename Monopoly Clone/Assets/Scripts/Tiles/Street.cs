using TMPro;
using UnityEngine;

namespace Tiles
{
    public class Street : Tile
    {
        [Header("Street Data")]
        [SerializeField] private ColourBlock colourBlock;
        [SerializeField] private TextMeshPro streetCostText;
        [SerializeField] private MeshRenderer streetColourBar;
            
        private void Start()
        {
            tileNameText.text = tileName;
            streetCostText.text = "£1Mil";
            streetColourBar.material.color = colourBlock.blockColour;
        }

        public override void OnLanded()
        {
            Debug.Log("Landed on: " + tileName);
        }
    }
}
