using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string Username => username;
    public float Money { get; set; }
    public Token Token => token;

    [SerializeField] private string username;
    [SerializeField] private Token token;
    private List<IPurchasable> _ownedProperties = new();

    public void PurchaseProperty(IPurchasable property)
    {
        if (property.Owner == null)
        {
            property.Purchase();
            _ownedProperties.Add(property);
        }
    }
}