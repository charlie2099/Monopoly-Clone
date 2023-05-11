using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DiceResultCalculator : MonoBehaviour
{
    public event Action<int> OnDiceRollCalculated;
    public event Action<int> OnDoubleRolled;

    [SerializeField] private DiceDetector diceDetector;
    private List<bool> _hasDiceLanded = new();
    private List<int> _diceRollOutput = new();
    private const int NumOfDice = 2;
    private int _diceIndex;
    private int _doublesRolled;

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
        _hasDiceLanded.Insert(_diceIndex, true);
        _diceRollOutput.Insert(_diceIndex, diceResult);

        _diceIndex++;

        if (_diceIndex == NumOfDice)
        {
            if (RolledADouble())
            {
                _doublesRolled++;
                OnDoubleRolled?.Invoke(_doublesRolled);
            }
            
            OnDiceRollCalculated?.Invoke(_diceRollOutput.Sum());
            _diceRollOutput.Clear();
            _diceIndex = 0;
        }
    }
    
    public bool RolledADouble()
    {
        return _diceRollOutput[0] == _diceRollOutput[1];
    }
}
