using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string Username => username;
    public float Money { get; set; }
    public Piece Piece => piece;
    //public List<Card> CardsInHand => _cardsInHand;

    [SerializeField] private string username;
    [SerializeField] private Piece piece;
    //private List<Card> _cardsInHand = new List<Card>();
}