using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    public static TurnController Instance;
    public event Action<Player> OnTurnChanged;
    
    [SerializeField] private TextMeshProUGUI playerTurnText;
    private Player _newActivePlayer;
    private int _turnIndex;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; 
        }
    }

    private void Start()
    {
        UpdateTurnText();
    }

    public void NextTurn() // called upon a click event via Next Turn button
    {
        /*if (!Dice.Instance.RolledADouble())
        {
            _turnIndex++;
            if (_turnIndex >= BoardMaster.Instance.Players.Count)
            {
                _turnIndex = 0;
            }
            
            Dice.Instance.DiceButton.SetActive(true);
            UpdateTurnText();

            _newActivePlayer = BoardMaster.Instance.Players[_turnIndex];
            OnTurnChanged?.Invoke(_newActivePlayer);
        }*/
    }

    private void UpdateTurnText()
    {
        playerTurnText.text = "Turn: <color=blue>" + BoardMaster.Instance.ActivePlayer.name + "</color>";
    }
}
