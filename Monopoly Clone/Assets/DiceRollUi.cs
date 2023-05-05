using TMPro;
using UnityEngine;

public class DiceRollUi : MonoBehaviour
{
    [SerializeField] private TMP_Text diceRollText;
    private DiceResultCalculator _diceResultCalculator;

    private void Awake() => _diceResultCalculator = GetComponent<DiceResultCalculator>();
    private void OnEnable() => _diceResultCalculator.OnDiceRollCalculated += UpdateDiceRollText;
    private void OnDisable() => _diceResultCalculator.OnDiceRollCalculated -= UpdateDiceRollText;

    private void UpdateDiceRollText(int sumOfDiceRoll)
    {
        diceRollText.text = $"Dice Roll: <color=red>{sumOfDiceRoll}</color>";
    }
}
