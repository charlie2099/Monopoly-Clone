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
    private List<IProperty> _ownedProperties = new();

    private void Awake()
    {
        BankAccount = new BankAccount();
    }

    public void BuyProperty(IProperty property)
    {
        if (property.HasOwner())
        {
            return;
        }
        _ownedProperties.Add(property);
        property.SetOwner(this);
        property.Purchase();
    }
}