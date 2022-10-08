using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiceRoller : MonoBehaviour
{
    public static DiceRoller Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public int DiceRollOutput => _diceRoll;
    
    [SerializeField] private TextMeshProUGUI diceRollText;
    private int _diceRoll;
    
    public void RollDice()
    {
        _diceRoll = Random.Range(1, 7);
        Debug.Log("Dice Roll: " + _diceRoll);
        diceRollText.text = _diceRoll.ToString();
    }
}
