using System;
using System.Collections.Generic;
using System.Linq;
using Tiles;
using UnityEngine;

/// <summary>
/// Responsible for moving pieces on the board and handling turn switching.
/// </summary>
public class BoardMaster : MonoBehaviour
{
    public static BoardMaster Instance;
    public event Action<Tile> OnTokenMoved;
    public event Action<Player> OnTurnChanged;
    public List<Player> Players => players;
    public List<Tile> Tiles => _tiles;
    public Player ActivePlayer => _activePlayer;

    [SerializeField] private List<Player> players;
    private List<Tile> _tiles = new();
    private Player _activePlayer;
    private int _turnIndex;
    private int _tileToMoveToID;
    private bool _pieceIsMoving;
    private float _randomXPos;
    private Vector3 _tileToMovePos;
    private Vector3 _transformDir;

    //private void OnEnable() => diceManager.OnDiceRolled += MovePiece;
    //private void OnDisable() => diceManager.OnDiceRolled -= MovePiece;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        Tile[] foundTiles = FindObjectsOfType<Tile>();
        _tiles.AddRange(foundTiles);
        _tiles = _tiles.OrderBy(tile => tile.TileID).ToList();
    }

    private void Start()
    {
        _activePlayer = players[0];
    }

    private void Update()
    {
        //Debug.DrawRay(_tileToMovePos, _transformDir, Color.magenta);
        if (_pieceIsMoving)
        {
            var playerPiece = _activePlayer.Token;
            var tileToMoveToPos = _tiles[_tileToMoveToID].transform.position;
            var newTilePos = new Vector3(tileToMoveToPos.x, playerPiece.transform.position.y, tileToMoveToPos.z);
            playerPiece.NavAgent.SetDestination(newTilePos/*new Vector3(_randomXPos, newTilePos.y, newTilePos.z)*/);

            if (playerPiece.NavAgent.hasPath)
            {
                if (playerPiece.NavAgent.remainingDistance < 0.5)
                {
                    playerPiece.SetCurrentTile(_tiles[_tileToMoveToID]);
                    playerPiece.CurrentTile.OnLanded();
                    OnTokenMoved?.Invoke(playerPiece.CurrentTile);
                    EndTurn();
                    _pieceIsMoving = false;
                }
            }
        }
    }

    /*private void MovePiece(int diceRollOne, int diceRollTwo)
    {
        if (_pieceIsMoving) { return; }
        
        var playerPiece = _activePlayer.Token;
        var currentTile = playerPiece.CurrentTile;
        int tileToMoveToID = currentTile.TileID + diceManager.DiceRollOutput;
        if (tileToMoveToID >= _tiles.Count)
        {
            int remainder = _tiles.Count - currentTile.TileID;
            tileToMoveToID = diceManager.DiceRollOutput - remainder;
        }
        _tileToMoveToID = tileToMoveToID;
        //_randomXPos = _tiles[tileToMoveToID].transform.position.x + (Random.insideUnitSphere.x * 1.75f);
        _pieceIsMoving = true;
    }*/

    private void EndTurn() // called upon a click event via End Turn button
    {
        _turnIndex++;
        if (_turnIndex >= Players.Count)
        {
            _turnIndex = 0;
        }
        _activePlayer = players[_turnIndex];
        OnTurnChanged?.Invoke(_activePlayer);
    }
}
