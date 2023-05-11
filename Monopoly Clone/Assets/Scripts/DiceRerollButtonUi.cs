using UnityEngine;

public class DiceRerollButtonUi : MonoBehaviour
{
    private DiceDetector diceDetector;
    private DiceRoller diceRoller;
    private DiceResultCalculator _diceResultCalculator;

    private void Awake()
    {
        diceDetector = FindObjectOfType<DiceDetector>();
        diceRoller = GetComponent<DiceRoller>();
        _diceResultCalculator = GetComponent<DiceResultCalculator>();
    }

    private void OnEnable()
    {
        diceDetector.OnDiceLandFailed += ReRoll;
        _diceResultCalculator.OnDiceRollCalculationFailed += ReRoll;
    }

    private void OnDisable()
    {
        diceDetector.OnDiceLandFailed -= ReRoll;
        _diceResultCalculator.OnDiceRollCalculationFailed -= ReRoll;
    }

    private void ReRoll()
    {
        diceRoller.Throw();
    }
}
