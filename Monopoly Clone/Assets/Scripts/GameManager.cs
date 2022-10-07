using System;
using System.Collections;
using System.Collections.Generic;
using Tiles;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public Player ActivePlayer() => _currentPlayer;
    public List<Tile> Tiles => tiles;
    
    [SerializeField] private List<Player> players;
    [SerializeField] private List<Tile> tiles;
    private Player _currentPlayer;
    private int _turnIndex;

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
            NextTurn();
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

    }
}
