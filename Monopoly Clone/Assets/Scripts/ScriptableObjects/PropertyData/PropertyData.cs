using System;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "PropertyData", menuName = "ScriptableObjects/PropertyData")]
    public class PropertyData : ScriptableObject
    {
        public PurchaseData purchaseData;
        public RentData rentData;
        public ColourBlock colourBlock;
    }

    [Serializable]
    public struct PurchaseData
    {
        public int purchaseCost;
        public int mortgageValue;
        public int housesCost;
        public int hotelsCost;
    }

    [Serializable]
    public struct RentData
    {
        public int rentWithNoHouses;
        public int rentWithOneHouse;
        public int rentWithTwoHouses;
        public int rentWithThreeHouses;
        public int rentWithFourHouses;
        public int rentWithHotels;
    }
}