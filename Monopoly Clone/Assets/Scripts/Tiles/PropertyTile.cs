using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tiles
{
    public class PropertyTile : Tile
    {
        [SerializeField] private PropertyData propertyData;
        [SerializeField] private TextMeshPro propertyTitleText;
        [SerializeField] private TextMeshPro propertyCostText;
        [SerializeField] private RawImage propertyImage;

        private void Start()
        {
            propertyTitleText.text = tileName;
            propertyCostText.text = "£" + propertyData.purchaseData.purchaseCost;
            //propertyImage.texture = propertyData.imageTexture;
            IsEmpty = true;
        }
    }
}