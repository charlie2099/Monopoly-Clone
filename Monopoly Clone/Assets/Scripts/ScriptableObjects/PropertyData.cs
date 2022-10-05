using System;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "PropertyData", menuName = "ScriptableObjects/PropertyData")]
    public class PropertyData : ScriptableObject
    {
        public string name;
        public Color colour;
        public Texture imageTexture;
        public PurchaseData purchaseData;
        public RentData rentData;
    }

    [Serializable]
    public struct PurchaseData
    {
        public float purchaseCost;
        public float mortgageValue;
        public float housesCost;
        public float hotelsCost;
    }

    [Serializable]
    public struct RentData
    {
        public float rentWithNoHouses;
        public float rentWithOneHouse;
        public float rentWithTwoHouses;
        public float rentWithThreeHouses;
        public float rentWithFourHouses;
        public float rentWithHotels;
    }
}