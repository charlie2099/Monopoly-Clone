using Commands;
using UnityEngine;
using UnityEngine.UI;

public class DiceRollInputHandler : MonoBehaviour
{
    [SerializeField] private Button rollDiceButton;
    private DiceRoller _diceRoller;

    private void Awake() => _diceRoller = GetComponent<DiceRoller>();
    private void OnEnable() => rollDiceButton.onClick.AddListener(Roll);
    private void OnDisable() => rollDiceButton.onClick.RemoveListener(Roll);

    private void Roll()
    {
        ICommand rollDiceCommand = new RollDiceCommand(_diceRoller);
        rollDiceCommand.Execute();
        rollDiceButton.gameObject.SetActive(false);
    }
}