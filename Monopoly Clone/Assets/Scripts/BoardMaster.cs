using System.Collections.Generic;
using Commands;
using Tiles;
using TMPro;
using UnityEngine;

public class BoardMaster : MonoBehaviour
{
    public static BoardMaster Instance;
    public List<Player> Players => players;
    public List<Tile> Tiles => tiles;
    public Player ActivePlayer => _currentPlayer;
    /*public Player ActivePlayer
    {
        get => _currentPlayer;
        set => _currentPlayer = value;
    }*/

    public bool PieceIsMoving => _pieceIsMoving;

    [SerializeField] private List<Player> players;
    [SerializeField] private List<Tile> tiles;
    [SerializeField] private TextMeshProUGUI tileText;
    private readonly CommandInvoker _commandInvoker = new();
    private Player _currentPlayer;
    private int _tileIndex;
    private bool _pieceIsMoving;

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
        tileText.text = "Tile: <color=blue>" + _currentPlayer.Piece.CurrentTile().name + "</color>";

        for (int i = 0; i < tiles.Count; i++)
        {
            tiles[i].TileID = i;
        }
    }

    private void Update()
    {
        // TODO: Call this with an event?
        tileText.text = "Tile: <color=blue>" + _currentPlayer.Piece.CurrentTile().name + "</color>";

        if (_pieceIsMoving)
        {
            var piece = _currentPlayer.Piece;
            var newTilePos = Tiles[_tileIndex].transform.position;
            var destination = new Vector3(newTilePos.x, _currentPlayer.Piece.transform.position.y, newTilePos.z);
            var speed = 5.0f * Time.deltaTime;
            piece.transform.position = Vector3.MoveTowards(piece.transform.position, destination, speed);

            if (piece.transform.position == destination)
            {
                piece.SetCurrentTile(Tiles[_tileIndex]);
                _pieceIsMoving = false;
            }
        }
    }

    public void MovePiece() 
    {
        var currentTile = _currentPlayer.Piece.CurrentTile();
        int tileIndex = currentTile.TileID + Dice.Instance.DiceRollOutput;
        if (tileIndex >= Tiles.Count)
        {
            int remainder = Tiles.Count - currentTile.TileID;
            tileIndex = Dice.Instance.DiceRollOutput - remainder;
        }
        _tileIndex = tileIndex;
        _pieceIsMoving = true;

        // TODO: Consider whether using the command pattern is actually necessary
        //       - Undo functionality and a command history isn't needed?
        //_commandInvoker.AddCommand(new MoveCommand(piece, currentTile, newTile));

        if (Dice.Instance.RolledADouble())
        {
            return;
        }
        Dice.Instance.DiceButton.SetActive(false);
    }

    public void SetActivePlayerByIndex(int listIndex)
    {
        _currentPlayer = players[listIndex];
    }
}
