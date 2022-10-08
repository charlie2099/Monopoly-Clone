using System;
using System.Collections;
using System.Collections.Generic;
using Commands;
using Tiles;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public Player ActivePlayer() => _currentPlayer;
    public List<Tile> Tiles => tiles;
    public int TurnCount => _turnCount;
    
    [SerializeField] private List<Player> players;
    [SerializeField] private List<Tile> tiles;
    private readonly CommandInvoker _commandInvoker = new();
    private int _tileIndex;
    private Player _currentPlayer;
    private int _turnIndex;
    private int _turnCount;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        _currentPlayer = players[0];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //NextTurn();
        }
    }

    public void NextTurn()
    {
        _turnIndex++;
        if (_turnIndex >= players.Count)
        {
            _turnIndex = 0;
        }
        _currentPlayer = players[_turnIndex];
        _turnCount++;
    }
    
    public void Move() 
    {
        //_commandInvoker.AddCommand(new MoveCommand(piece, piece.CurrentTile(), GameManager.Instance.Tiles[Random.Range(0, GameManager.Instance.Tiles.Count)]));
        if (_tileIndex == Tiles.Count)
        {
            _tileIndex = 0;
        }

        // assign an id to each tile
        // GameManager.Instance.Tiles[piece.CurrentTile().GetTileID + Dice.RollCount]
        _commandInvoker.AddCommand(new MoveCommand(_currentPlayer.Piece, _currentPlayer.Piece.CurrentTile(),Tiles[_tileIndex+=DiceRoller.Instance.DiceRollOutput]));
        NextTurn();
    }
}
