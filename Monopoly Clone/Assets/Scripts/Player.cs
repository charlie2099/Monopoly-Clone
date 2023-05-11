﻿using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string Username => username;
    public float Balance { get; set; }
    public Token Token => token;

    [SerializeField] private string username;
    [SerializeField] private Token token;
    private List<IPurchasable> _ownedProperties = new();

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
}