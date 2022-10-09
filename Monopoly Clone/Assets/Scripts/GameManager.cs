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
    [SerializeField] private TextMeshProUGUI playerTurnText;
    [SerializeField] private TextMeshProUGUI tileText;
    
    private readonly CommandInvoker _commandInvoker = new();
    private Player _currentPlayer;
    private int _turnIndex;
    private int _turnCount;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _currentPlayer = players[0];
        playerTurnText.text = "Turn: <color=blue>" + _currentPlayer.name + "</color>";
        tileText.text = "Tile: <color=blue>" + _currentPlayer.Piece.CurrentTile().name + "</color>";

        for (int i = 0; i < tiles.Count; i++)
        {
            tiles[i].TileID = i;
        }
    }

    public void Move() 
    {
        var piece = _currentPlayer.Piece;
        var currentTile = _currentPlayer.Piece.CurrentTile();
        int tileIndex = currentTile.TileID + Dice.Instance.DiceRollOutput;
        if (tileIndex >= Tiles.Count)
        {
            int remainder = Tiles.Count - currentTile.TileID;
            tileIndex = Dice.Instance.DiceRollOutput - remainder;
        }
        
        var newTile = Tiles[tileIndex];
        _commandInvoker.AddCommand(new MoveCommand(piece, currentTile, newTile));
        
        NextTurn();
    }
    
    public void NextTurn()
    {
        _turnIndex++;
        if (_turnIndex >= players.Count)
        {
            _turnIndex = 0;
        }
        _currentPlayer = players[_turnIndex];
        playerTurnText.text = "Turn: <color=blue>" + _currentPlayer.name + "</color>";
        tileText.text = "Tile: <color=blue>" + _currentPlayer.Piece.CurrentTile().name + "</color>";
        _turnCount++;
    }
}
