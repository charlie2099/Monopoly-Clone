using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour
{
    public event Action<int, int> OnDiceRolled;
    public event Action<int> OnDoubleRolled;
    public int DiceRollOutput => _diceOneRoll+_diceTwoRoll;
    public int DoublesRolled => _doublesRolled;
    
    private int _diceOneRoll;
    private int _diceTwoRoll;
    private int _doublesRolled;

    public void Roll() // called upon a click event via Roll Turn button
    {
        _diceOneRoll = Random.Range(1, 7);
        _diceTwoRoll = Random.Range(1, 7);
        OnDiceRolled?.Invoke(_diceOneRoll, _diceTwoRoll);

        if (RolledADouble())
        {
            _doublesRolled++;
            OnDoubleRolled?.Invoke(_doublesRolled);
            return;
        }
        _doublesRolled = 0;
    }

    private bool RolledADouble()
    {
        if (_diceOneRoll == _diceTwoRoll)
        {
            return true;
        }
        return false;
    }
}
