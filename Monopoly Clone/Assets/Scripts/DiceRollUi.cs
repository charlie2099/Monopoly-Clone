using TMPro;
using UnityEngine;

public class DiceRollUi : MonoBehaviour
{
    [SerializeField] private GameManager gameManager; // TODO: Clean this
    [SerializeField] private TMP_Text diceRollText;
    private DiceResultCalculator _diceResultCalculator;

    private void Awake() => _diceResultCalculator = GetComponent<DiceResultCalculator>();
    private void OnEnable()
    {
        _diceResultCalculator.OnDiceRollCalculated += UpdateDiceRollText;
        gameManager.OnTurnChanged += UpdateDiceRollText_OnTurnChanged;
    }

    private void OnDisable()
    {
        _diceResultCalculator.OnDiceRollCalculated -= UpdateDiceRollText;
        gameManager.OnTurnChanged -= UpdateDiceRollText_OnTurnChanged;
    }

    private void UpdateDiceRollText(int sumOfDiceRoll)
    {
        diceRollText.text = $"Dice Roll: <color=red>{sumOfDiceRoll}</color>";
    }
    
    private void UpdateDiceRollText_OnTurnChanged(Player player)
    {
        diceRollText.text = $"Dice Roll:";
    }
}
