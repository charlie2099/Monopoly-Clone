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
        _diceRoller.Throw();
        rollDiceButton.gameObject.SetActive(false);
    }
}