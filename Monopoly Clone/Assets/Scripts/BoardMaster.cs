using System;
using System.Collections;
using System.Collections.Generic;
using Commands;
using Tiles;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Responsible for moving pieces on the board and deciding
/// whose turn it is.
/// </summary>

public class BoardMaster : MonoBehaviour
{
    public static BoardMaster Instance;
    public event Action<Tile> OnPieceMoved;
    public event Action<Player> OnTurnChanged;
    public List<Player> Players => players;
    public List<Tile> Tiles => tiles;
    public Player ActivePlayer => _activePlayer;
    public Dice Dice => dice;

    [SerializeField] private Dice dice; //tight coupling? 
    [SerializeField] private List<Player> players;
    [SerializeField] private List<Tile> tiles;
    private Player _activePlayer;
    private int _turnIndex;
    private int _tileToMoveToID;
    private bool _pieceIsMoving;
    private float _randomXPos;
    
    private Vector3 _tileToMovePos;
    private Vector3 _transformDir;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _activePlayer = players[0];

        for (int i = 0; i < tiles.Count; i++)
        {
            tiles[i].TileID = i;
        }
    }

    private void Update()
    {
        //Debug.DrawRay(_tileToMovePos, _transformDir, Color.magenta);

        if (_pieceIsMoving)
        {
            var playerPiece = _activePlayer.Piece;
            var tileToMoveToPos = Tiles[_tileToMoveToID].transform.position;
            var newTilePos = new Vector3(tileToMoveToPos.x, playerPiece.transform.position.y, tileToMoveToPos.z);
            playerPiece.NavAgent.SetDestination(newTilePos/*new Vector3(_randomXPos, newTilePos.y, newTilePos.z)*/);
            //var speed = 5.0f * Time.deltaTime;
            //playerPiece.transform.position = Vector3.MoveTowards(playerPiece.transform.position, newTilePos, speed);

            if (playerPiece.NavAgent.hasPath)
            {
                if (playerPiece.NavAgent.remainingDistance < 0.5)
                {
                    playerPiece.SetCurrentTile(Tiles[_tileToMoveToID]);
                    OnPieceMoved?.Invoke(playerPiece.CurrentTile);
                    _pieceIsMoving = false;
                }
            }
        }
    }

    public void MovePiece() // called upon a click event via Roll Dice button
    {
        var playerPiece = _activePlayer.Piece;
        var currentTile = playerPiece.CurrentTile;
        int tileToMoveToID = currentTile.TileID + dice.DiceRollOutput;
        if (tileToMoveToID >= Tiles.Count)
        {
            int remainder = Tiles.Count - currentTile.TileID;
            tileToMoveToID = dice.DiceRollOutput - remainder;
        }
        _tileToMoveToID = tileToMoveToID;

        //_randomXPos = Tiles[tileToMoveToID].transform.position.x + (Random.insideUnitSphere.x * 1.75f);
        
        _pieceIsMoving = true;
        
        // TODO:
        // Fire a raycast down onto the tile that is being moved to, check for pieces, and adjust the position of the
        // pieces to be spaced apart from each other.
        // OR
        // Fire a raycast in the direction the piece is moving and adjust the moving piece to position next to piece
        // in front of it.
        
        /*//var pieceOffsetPos = 0;
        
        RaycastHit hitInfo;
        if (Physics.Raycast(tileToMoveToPos + Vector3.up*5, transform.TransformDirection(Vector3.down), out hitInfo))
        {
            _tileToMovePos = tileToMoveToPos + Vector3.up*5;
            _transformDir = transform.TransformDirection(Vector3.down) * hitInfo.distance;

            if (hitInfo.transform.GetComponent<Piece>() != null)
            {
                //pieceOffsetPos = 2;
                Debug.Log("Piece at center of tile to move to");
            }
        }*/

        //var width = Tiles[tileToMoveToID].transform.GetComponent<Renderer>().bounds.size.x;
        //var tileToMoveToPos = Tiles[tileToMoveToID].transform.position;
        //var newTilePos = new Vector3(tileToMoveToPos.x /*+ pieceOffsetPos*/, playerPiece.transform.position.y, tileToMoveToPos.z);
        //playerPiece.transform.position = newTilePos;

        /*playerPiece.SetCurrentTile(Tiles[tileToMoveToID]);
        OnPieceMoved?.Invoke(playerPiece.CurrentTile);*/

        /*var currentTile = _currentPlayer.Piece.CurrentTile();
        //int tileToMoveToID = currentTile.TileID + Dice.Instance.DiceRollOutput;
        int nextTileToMoveToID = currentTile.TileID + 1;
        
        if (nextTileToMoveToID >= Tiles.Count)
        {
            int remainder = Tiles.Count - currentTile.TileID;
            nextTileToMoveToID = 1 - remainder;
        }
        
        _nextTileID = nextTileToMoveToID;
        _pieceIsMoving = true;*/

        /*var currentTile = _currentPlayer.Piece.CurrentTile();
        int tileToMoveToID = currentTile.TileID + Dice.Instance.DiceRollOutput;
        
        if (tileToMoveToID >= Tiles.Count)
        {
            int remainder = Tiles.Count - currentTile.TileID;
            tileToMoveToID = Dice.Instance.DiceRollOutput - remainder;
        }
        _tileToMoveToID = tileToMoveToID;
        _pieceIsMoving = true;*/

        // TODO: Consider whether using the command pattern is actually necessary
        //       - Undo functionality and a command history isn't needed?
        //_commandInvoker.AddCommand(new MoveCommand(piece, currentTile, newTile));
    }
    
    public void EndTurn() // called upon a click event via End Turn button
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
