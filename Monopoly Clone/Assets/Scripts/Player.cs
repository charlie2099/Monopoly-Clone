using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string Username => username;
    public float Money { get; set; }
    public Piece Piece => piece;
    public List<IPurchaseable> OwnedProperties => _ownedProperties;
    //public List<Card> CardsInHand => _cardsInHand;

    [SerializeField] private string username;
    [SerializeField] private Piece piece;
    private List<IPurchaseable> _ownedProperties;
    //private List<Card> _cardsInHand = new List<Card>();
    
    public void BuyProperty(IPurchaseable property)
    {
        // if property not already owned, add it to the list
        _ownedProperties.Add(property);
    }

    public void Buy()
    {
        Debug.Log("BUY");
    }
}