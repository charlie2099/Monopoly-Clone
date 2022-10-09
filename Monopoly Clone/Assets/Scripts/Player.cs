using System;
using Commands;
using Tiles;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    public float Money { get; set; }
    public Piece Piece => piece;
    
    [SerializeField] private Piece piece;
}