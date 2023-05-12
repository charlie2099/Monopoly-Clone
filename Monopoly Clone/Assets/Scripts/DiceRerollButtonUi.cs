using Commands;
using UnityEngine;

public class DiceRerollButtonUi : MonoBehaviour
{
    private DiceDetector _diceDetector;
    private DiceRoller _diceRoller;
    private DiceResultCalculator _diceResultCalculator;

    private void Awake()
    {
        _diceDetector = FindObjectOfType<DiceDetector>();
        _diceRoller = GetComponent<DiceRoller>();
        _diceResultCalculator = GetComponent<DiceResultCalculator>();
    }

    private void OnEnable()
    {
        _diceDetector.OnDiceLandFailed += ReRoll;
        _diceResultCalculator.OnDiceRollCalculationFailed += ReRoll;
    }

    private void OnDisable()
    {
        _diceDetector.OnDiceLandFailed -= ReRoll;
        _diceResultCalculator.OnDiceRollCalculationFailed -= ReRoll;
    }

    private void ReRoll()
    {
        ICommand rollDiceCommand = new RollDiceCommand(_diceRoller);
        rollDiceCommand.Execute();
    }
}
