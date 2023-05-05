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
    private Dictionary<Player, WaypointSequence> playerPathDict;
    private List<WaypointSequence> waypointSequences = new();
    private List<Player> _players = new();
    private List<Tile> _tiles = new();
    private Player _activePlayer;
    private int _turnIndex;
    private int _tileToMoveToID;
    private bool _tokenIsMoving;
    private float _randomXPos;
    private Vector3 _tileToMovePos;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
        waypointSequences.AddRange(FindObjectsOfType<WaypointSequence>().OrderBy(sequence => sequence.name));
        _tiles.AddRange(FindObjectsOfType<Tile>().OrderBy(tile => tile.TileNum));
        _players.AddRange(FindObjectsOfType<Player>().OrderBy(player => player.Username));
        playerPathDict = new Dictionary<Player, WaypointSequence>
        {
            {_players[0], waypointSequences[0]},
            {_players[1], waypointSequences[1]},
            {_players[2], waypointSequences[2]},
            {_players[3], waypointSequences[3]}
        };
    }
    
    private void OnEnable() => diceResultCalculator.OnDiceRollCalculated += MoveToken;
    private void OnDisable() => diceResultCalculator.OnDiceRollCalculated += MoveToken;
    private void Start() => _activePlayer = _players[0];

    private void Update()
    {
        if (_tokenIsMoving)
        {
            var playerToken = _activePlayer.Token;
            var targetWaypoint = playerPathDict[_activePlayer].GetWaypoint(_tileToMoveToID);
            var targetWaypointPos = targetWaypoint.transform.position;
            
            playerToken.transform.position = Vector3.MoveTowards(playerToken.transform.position, targetWaypointPos, 5.0f * Time.deltaTime);
            playerToken.transform.LookAt(targetWaypointPos);
            
            if (playerToken.transform.position == targetWaypointPos)
            {
                playerToken.SetCurrentTile(_tiles[_tileToMoveToID]);
                playerToken.CurrentTile.OnLanded();
                OnTokenMoved?.Invoke(playerToken.CurrentTile);
                EndTurn();
                _tokenIsMoving = false;  
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
