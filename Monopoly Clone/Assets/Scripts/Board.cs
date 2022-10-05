using System.Collections.Generic;
using Tiles;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static Board Instance;
    
    [SerializeField] private List<PropertyTile> tiles;
    [SerializeField] private List<Piece> pieces;
    // public CommandInvoker _commandInvoker;
    // BoardData scriptable object?

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Only one instance of Board should exist at any one time!");
        }
    }

    private void Start()
    {
        foreach (var tile in tiles)
        {
            foreach (var piece in pieces)
            {
                if (piece.CurrentTile() == tile)
                {
                    tile.IsEmpty = false;
                }
            }
        }
    }

    private void AssembleBoard()
    {
        // Moves all pieces to start position
        /*foreach (var piece in pieces)
        {
            _commandInvoker.AddCommand(new MoveCommand(piece, null, tiles[0]));
        }*/
        
        // Sets the board (back?) to it's starting state, positioning all pieces and
        // dice at their starting positions, houses and hotels are cleared from the
        // board, each player's cash is reset to the starting amount, and special cards
        // are placed back into the stack. 
    }
}
