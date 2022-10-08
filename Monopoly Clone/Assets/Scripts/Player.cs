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
    private readonly CommandInvoker _commandInvoker = new();
    private int _tileIndex;

    /*public void Move() 
    {
        if (GameManager.Instance.ActivePlayer() == this) // necessary?
        {
            //_commandInvoker.AddCommand(new MoveCommand(piece, piece.CurrentTile(), GameManager.Instance.Tiles[Random.Range(0, GameManager.Instance.Tiles.Count)]));
            if (_tileIndex == GameManager.Instance.Tiles.Count)
            {
                _tileIndex = 0;
            }

            // assign an id to each tile
            // GameManager.Instance.Tiles[piece.CurrentTile().GetTileID + Dice.RollCount]
            _commandInvoker.AddCommand(new MoveCommand(piece, piece.CurrentTile(),
                GameManager.Instance.Tiles[_tileIndex+=DiceRoller.Instance.DiceRollOutput]));
        }
    }*/
}