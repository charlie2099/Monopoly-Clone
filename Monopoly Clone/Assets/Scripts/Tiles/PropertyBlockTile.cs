using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tiles
{
    public class PropertyBlockTile : Tile
    {
        [SerializeField] private PropertyData propertyData;
        [SerializeField] private TextMeshPro propertyTitleText;
        [SerializeField] private TextMeshPro propertyCostText;
        [SerializeField] private MeshRenderer propertyColourBar;
        [SerializeField] private RawImage propertyImage;

        private void Start()
        {
            propertyTitleText.text = tileName;
            propertyCostText.text = "£" + propertyData.purchaseData.purchaseCost; 
            propertyColourBar.material.color = Color.grey;
            //propertyImage.texture = propertyData.imageTexture;
            IsEmpty = true;
        }
    }
}
