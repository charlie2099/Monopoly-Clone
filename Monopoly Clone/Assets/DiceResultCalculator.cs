using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DiceResultCalculator : MonoBehaviour
{
    public event Action<int> OnDiceCalculated;
    public event Action<int> OnDoubleRolled;
    public int DiceRollOutput => _diceRollOutput.Sum();
    public int DoublesRolled => _doublesRolled;
    
    [SerializeField] private DiceDetector diceDetector;
    private List<bool> _hasDiceLanded = new();
    private List<int> _diceRollOutput = new();
    private int _diceIndex;
    private int _doublesRolled;
    private const int NumOfDice = 2;

    private void Awake()
    {
        for (var i = 0; i < NumOfDice; i++)
        {
            _hasDiceLanded.Add(false);
            _diceRollOutput.Add(0);
        }
    }

    private void OnEnable() => diceDetector.OnDiceResult += CalculateRoll;
    private void OnDisable() => diceDetector.OnDiceResult -= CalculateRoll;

    private void CalculateRoll(int diceResult)
    {
        Debug.Log(diceResult);
        _hasDiceLanded.Insert(_diceIndex, true);
        _diceRollOutput.Insert(_diceIndex, diceResult);
        
        // rules

        _diceIndex++;

        if (_diceIndex == NumOfDice)
        {
            OnDiceCalculated?.Invoke(_diceRollOutput.Sum());
            _diceIndex = 0;
        }

        /*if (_diceOneRoll == 0)
        {
            _diceOneRoll = diceResult;
            return;
        }

        // if diceOne result already captured, capture 2nd dice result
        _diceTwoRoll = diceResult;

        OnDiceRolled?.Invoke(_diceOneRoll, _diceTwoRoll);

        if (RolledADouble())
        {
            _doublesRolled++;
            OnDoubleRolled?.Invoke(_doublesRolled);
            _diceOneRoll = 0;
            _diceTwoRoll = 0;
            _diceRoller.HideDice();
            _diceRoller.ResetDice();
            return;
        }
        _doublesRolled = 0;
        _diceOneRoll = 0;
        _diceTwoRoll = 0;

        _diceRolled = false;*/
    }
    
    private bool RolledADouble()
    {
        return _diceRollOutput[0] == _diceRollOutput[1];
    }
}
