using System;
using System.Collections.Generic;
using System.Linq;
using Tiles;
using UnityEngine;

/// <summary>
/// Responsible for moving pieces on the board and handling turn switching.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public event Action<Tile> OnTokenMoved;
    public event Action<Player> OnTurnChanged;
    public List<Tile> Tiles => _tiles;
    public Player ActivePlayer => _activePlayer;

    [SerializeField] private DiceResultCalculator diceResultCalculator;
    private List<Player> _players = new();
    private List<Tile> _tiles = new();
    private Player _activePlayer;
    private int _turnIndex;
    private int _tileToMoveToID;
    private bool _tokenIsMoving;
    private float _randomXPos;
    private Vector3 _tileToMovePos;
    private Vector3 _transformDir;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
        _tiles.AddRange(FindObjectsOfType<Tile>().OrderBy(tile => tile.TileNum));
        _players.AddRange(FindObjectsOfType<Player>().OrderBy(player => player.Username));
    }
    
    private void OnEnable() => diceResultCalculator.OnDiceRollCalculated += MoveToken;
    private void OnDisable() => diceResultCalculator.OnDiceRollCalculated += MoveToken;
    private void Start() => _activePlayer = _players[0];

    private void Update()
    {
        //Debug.DrawRay(_tileToMovePos, _transformDir, Color.magenta);
        if (_tokenIsMoving)
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
                    _tokenIsMoving = false;
                }
            }
        }
    }

    private void MoveToken(int spacesToMove)
    {
        if (_tokenIsMoving) { return; }
        
        var playerToken = _activePlayer.Token;
        var currentTile = playerToken.CurrentTile;
        int tileToMoveToID = currentTile.TileNum + spacesToMove;
        if (tileToMoveToID >= _tiles.Count)
        {
            int remainder = _tiles.Count - currentTile.TileNum;
            tileToMoveToID = spacesToMove - remainder;
        }
        _tileToMoveToID = tileToMoveToID;
        _tokenIsMoving = true;
    }

    private void EndTurn() 
    {
        _turnIndex++;
        if (_turnIndex >= _players.Count)
        {
            _turnIndex = 0;
        }
        _activePlayer = _players[_turnIndex];
        OnTurnChanged?.Invoke(_activePlayer);
    }
}
