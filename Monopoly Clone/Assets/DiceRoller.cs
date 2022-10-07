using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI diceRollText;
    private int _diceRoll;
    
    public void RollDice()
    {
        _diceRoll = Random.Range(1, 7);
        Debug.Log("Dice Roll: " + _diceRoll);
        diceRollText.text = _diceRoll.ToString();
    }
}
