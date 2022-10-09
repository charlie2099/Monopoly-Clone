using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour
{
    public static Dice Instance;

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
    
    public void Roll()
    {
        _diceRoll = Random.Range(1, 7);
        diceRollText.text = _diceRoll.ToString();
    }
}
