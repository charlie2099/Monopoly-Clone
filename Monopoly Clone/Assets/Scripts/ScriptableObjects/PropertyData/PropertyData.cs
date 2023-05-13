using System;
using UnityEngine;

namespace ScriptableObjects.PropertyData
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
        public int[] rentLevels;

        public int GetRentLevel(RentLevel rentLevel)
        {
            int index = (int)rentLevel;
            if (index >= 0 && index < rentLevels.Length)
            {
                return rentLevels[index];
            }
            else
            {
                throw new IndexOutOfRangeException("Invalid rent level");
            }
        }
    }

    public enum RentLevel
    {
        NoHouses,
        OneHouse,
        TwoHouses,
        ThreeHouses,
        FourHouses,
        Hotel
    }
}