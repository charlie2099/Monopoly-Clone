using Interfaces;
using ScriptableObjects.PropertyData;
using Tiles;

public class PropertyFactory
{
    public static IPurchasable CreateDrone(PropertyType propertyType, PropertyData propertyData)
    {
        IPurchasable property = null;

        switch (propertyType)
        {
            case PropertyType.Street:
                property = new Street();
                break;
            case PropertyType.Railroad:
                property = new Railroad();
                break;
            case PropertyType.Utility:
                property = new Utility();
                break;
        }
        
        return property;
    }

    public enum PropertyType
    {
        Street,
        Railroad,
        Utility
    }
}
