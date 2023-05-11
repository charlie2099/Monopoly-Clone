using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DiceResultCalculator : MonoBehaviour
{
    public event Action<int> OnDiceRollCalculated;
    public event Action OnDiceRollCalculationFailed;
    public event Action<int> OnDoubleRolled;

    [SerializeField] private DiceDetector diceDetector;
    private Coroutine _checkDiceResultHasFailedCoroutine;
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
        
        if (_checkDiceResultHasFailedCoroutine == null)
        {
            _checkDiceResultHasFailedCoroutine = StartCoroutine(BeginDiceResultFailedCheck());
        }

        if (_diceIndex == NumOfDice)
        {
            StopCoroutine(_checkDiceResultHasFailedCoroutine);
            _checkDiceResultHasFailedCoroutine = null;
            
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
    
    /// <summary>
    /// Invokes a failure event if one of the dice fails to produce a result after x amount of time
    /// </summary>
    private IEnumerator BeginDiceResultFailedCheck()
    {
        yield return new WaitForSeconds(5f);
        OnDiceRollCalculationFailed?.Invoke();
        _diceRollOutput.Clear();
        _diceIndex = 0;
        _checkDiceResultHasFailedCoroutine = null;
    }
}
