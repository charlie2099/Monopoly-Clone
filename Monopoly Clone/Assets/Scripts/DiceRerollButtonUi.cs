using UnityEngine;

public class DiceRerollButtonUi : MonoBehaviour
{
    private DiceDetector diceDetector;
    private DiceRoller diceRoller;

    private void Awake()
    {
        diceDetector = FindObjectOfType<DiceDetector>();
        diceRoller = GetComponent<DiceRoller>();
    }

    private void OnEnable() => diceDetector.OnDiceResultFailed += ReRoll;
    private void OnDisable() => diceDetector.OnDiceResultFailed -= ReRoll;

    private void ReRoll()
    {
        Debug.Log("Test");
        diceRoller.Throw();
    }
}
