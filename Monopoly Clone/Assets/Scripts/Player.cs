using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public string Username => username;
    public float Money { get; set; }
    public Token Token => token;
    public List<IPurchaseable> OwnedProperties => _ownedProperties;
    //public List<Card> CardsInHand => _cardsInHand;

    [SerializeField] private string username;
    [FormerlySerializedAs("piece")] [SerializeField] private Token token;
    private List<IPurchaseable> _ownedProperties;
    //private List<Card> _cardsInHand = new List<Card>();
    
    public void BuyProperty(IPurchaseable property)
    {
        property.Buy();
        
        // if property not already owned, add it to the list
        _ownedProperties.Add(property);
    }
}