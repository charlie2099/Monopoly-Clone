using UnityEngine;
using UnityEngine.UI;

public class DiceManager : MonoBehaviour
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

    private void CalculateDiceOutput(int diceResult)
    {
        Debug.Log(diceResult);
        //_diceRoller.HideDice();
        
        
        
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
        
        
        
        //_diceRoller.HideDice();
        //_diceRoller.ResetDice();
    }
}
