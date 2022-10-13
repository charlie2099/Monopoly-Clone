using System;
using System.Collections.Generic;
using Commands;
using Tiles;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    public float Money { get; set; }
    public Piece Piece => piece;
    public List<Card> CardsInHand => _cardsInHand;

    [SerializeField] private Piece piece;
    private List<Card> _cardsInHand = new List<Card>();
}