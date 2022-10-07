using System;
using Commands;
using Tiles;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    [SerializeField] private Piece piece;
    private readonly CommandInvoker _commandInvoker = new();

    private void Update()
    {
        if (GameManager.Instance.ActivePlayer() == this)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                _commandInvoker.AddCommand(new MoveCommand(piece, piece.CurrentTile(), GameManager.Instance.Tiles[Random.Range(0, GameManager.Instance.Tiles.Count)]));
            }
        }
    }
}