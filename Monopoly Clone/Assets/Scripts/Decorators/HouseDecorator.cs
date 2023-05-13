using Interfaces;
using ScriptableObjects.PropertyData;

namespace Decorators
{
    public class HouseDecorator : IProperty
    {
        private IProperty decoratedProperty;
        public PropertyData PropertyData => decoratedProperty.PropertyData;
        private int houseCount;

        public HouseDecorator(IProperty property)
        {
            decoratedProperty = property;
            houseCount = 0;
        }

        public void Upgrade()
        {
            decoratedProperty.Upgrade(); // Perform the base upgrade logic
            houseCount++; // Increase the house count
        }

        public void Downgrade()
        {
            if (houseCount > 0)
            {
                decoratedProperty.Downgrade(); // Perform the base downgrade logic
                houseCount--; // Decrease the house count
            }
        }

        public void Purchase()
        {
            decoratedProperty.Purchase(); // Perform the base purchase logic
        }

        public void Mortgage()
        {
            decoratedProperty.Mortgage(); // Perform the base mortgage logic
        }

        public void SetOwner(Player player)
        {
            decoratedProperty.SetOwner(player); // Perform the base set owner logic
        }

        public Player HasOwner()
        {
            return decoratedProperty.HasOwner(); // Perform the base has owner logic
        }

        public int GetRentPrice()
        {
            int baseRentLevel = PropertyData.rentData.GetRentLevel(RentLevel.NoHouses);
            int totalRentLevel = baseRentLevel + houseCount;

            if (totalRentLevel >= (int)RentLevel.Hotel)
            {
                totalRentLevel = (int)RentLevel.Hotel;
            }

            int rentPrice = PropertyData.rentData.GetRentLevel((RentLevel)totalRentLevel);
            return rentPrice;
        }
    }

}