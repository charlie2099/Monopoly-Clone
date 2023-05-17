using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string Username => username;
    public BankAccount BankAccount { get; private set; }
    public Token Token => token;

    [SerializeField] private string username;
    [SerializeField] private Token token;
    private readonly List<IPurchasable> _ownedProperties = new();

    private void Awake()
    {
        BankAccount = new BankAccount();
    }

    public void BuyProperty(IPurchasable property)
    {
        if (property.HasOwner())
        {
            return;
        }
        _ownedProperties.Add(property);
        property.SetOwner(this);
        property.Purchase();
    }
    
    /*public bool HasMonopoly(List<ColourBlock> colourBlock)
    {
        foreach (var colorGroup in colourBlock)
        {
            bool monopoly = true;
            foreach (Property property in colorGroup.properties)
            {
                if (property.ownerID != playerID)
                {
                    monopoly = false;
                    break;
                }
            }

            if (monopoly)
            {
                return true; // Player has a monopoly
            }
        }

        return false; // Player doesn't have a monopoly
    }*/
}