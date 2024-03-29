using System;
using System.Collections.Generic;
using System.Linq;
using Commands;
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
    public List<Player> Players => _players;
    public Player ActivePlayer => _activePlayer;
    public int PlayerCount => _players.Count;

    public Dictionary<Player, WaypointSequence> playerPathDict;
    private DiceResultCalculator _diceResultCalculator;
    private List<WaypointSequence> _waypointSequences = new();
    private List<Player> _players = new();
    private List<Tile> _tiles = new();
    private Player _activePlayer;
    private PlayerTurn playerTurn = new PlayerTurn();
    private int _turnIndex;
    private int _targetTileIndex;
    private bool _tokenIsMoving;
    private bool _passedGo;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _diceResultCalculator = FindObjectOfType<DiceResultCalculator>();
        _waypointSequences.AddRange(FindObjectsOfType<WaypointSequence>().OrderBy(sequence => sequence.name));
        _tiles.AddRange(FindObjectsOfType<Tile>().OrderBy(tile => tile.TileNum));
        _players.AddRange(FindObjectsOfType<Player>().OrderBy(player => player.Username));
        playerPathDict = new Dictionary<Player, WaypointSequence>
        {
            {_players[0], _waypointSequences[0]},
            {_players[1], _waypointSequences[1]},
            {_players[2], _waypointSequences[2]},
            {_players[3], _waypointSequences[3]}
        };
    }
    
    private void OnEnable() => _diceResultCalculator.OnDiceRollCalculated += CalculateTargetTile;
    private void OnDisable() => _diceResultCalculator.OnDiceRollCalculated += CalculateTargetTile;
    private void Start()
    {
        _activePlayer = _players[0];
        _players.ForEach(player => Bank.SetStartingFunds(player.BankAccount, 1500));
    }

    private void Update()
    {
        if (_tokenIsMoving)
        {
            //playerTurn.ExecuteCommands();

            var playerToken = _activePlayer.Token;
            Tile targetTile = _tiles[_targetTileIndex];

            if (playerToken.CurrentTile != targetTile)
            {
                int nextTileNum = playerToken.CurrentTile.TileNum + 1;
                if (nextTileNum >= _tiles.Count)
                {
                    if (!_passedGo)
                    {
                        Bank.Deposit(_activePlayer.BankAccount, 250);
                        _passedGo = true;
                    }
                    nextTileNum = 0;
                }

                Waypoint nextTileWaypoint = playerPathDict[_activePlayer].GetWaypoint(nextTileNum);
                playerToken.transform.position = Vector3.MoveTowards(playerToken.transform.position, nextTileWaypoint.transform.position, 5.0f * Time.deltaTime);
                playerToken.transform.LookAt(nextTileWaypoint.transform.position);

                if (playerToken.transform.position == nextTileWaypoint.transform.position)
                {
                    playerToken.SetCurrentTile(_tiles[nextTileNum]);
                    
                    if (playerToken.CurrentTile == targetTile)
                    {
                        playerToken.CurrentTile.OnLanded(_activePlayer);
                        OnTokenMoved?.Invoke(playerToken.CurrentTile);
                        _tokenIsMoving = false;
                    }
                }
            }
        }
    }

    private void CalculateTargetTile(int spacesToMove)
    {
        if (_tokenIsMoving) return;
    
        var playerToken = _activePlayer.Token;
        var currentTile = playerToken.CurrentTile;
        var tileToMoveToID = (currentTile.TileNum + spacesToMove) % _tiles.Count;
        _targetTileIndex = tileToMoveToID;

        //ICommand moveCommand = new MoveCommand(_activePlayer, _tiles[_targetTileIndex], _tiles.ToArray());
        //playerTurn.AddCommand(moveCommand);
        _tokenIsMoving = true;
        _passedGo = false;
    }

    public void EndTurn() 
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

//MoveCommand moveCommand = new MoveCommand(playerToken, currentTile, _tiles[tileToMoveToID]);