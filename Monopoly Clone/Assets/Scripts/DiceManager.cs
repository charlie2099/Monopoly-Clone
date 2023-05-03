using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DiceManager : MonoBehaviour
{
    public event Action<int, int> OnDiceRolled;
    public event Action<int> OnDoubleRolled;
    public int DiceRollOutput => _diceOneRoll+_diceTwoRoll;
    public int DoublesRolled => _doublesRolled;

    [SerializeField] private Button rollDiceButton;
    [SerializeField] private DiceDetector diceDetector; 
    [SerializeField] private GameObject dicePrefab;
    [SerializeField] private Transform diceThrowerOne;
    [SerializeField] private Transform diceThrowerTwo;
    private Rigidbody _diceRb;
    private int _diceOneRoll;
    private int _diceTwoRoll;
    private int _doublesRolled;

    private void OnEnable()
    {
        rollDiceButton.onClick.AddListener(Roll);
        diceDetector.OnDiceResult += CalculateDiceOutput;
    }
    
    private void OnDisable()
    {
        rollDiceButton.onClick.RemoveListener(Roll);
        diceDetector.OnDiceResult -= CalculateDiceOutput;
    }

    private void Roll() // called upon a click event via Roll Turn button
    {
        // Instantiating not ideal
        GameObject dice1Instance = Instantiate(dicePrefab, diceThrowerOne.position, Quaternion.identity);
        float dirX1 = Random.Range(0, 500);
        float dirY1 = Random.Range(0, 500);
        float dirZ1 = Random.Range(0, 500);
        dice1Instance.GetComponent<Rigidbody>().AddForce(-transform.right * 350);
        dice1Instance.GetComponent<Rigidbody>().AddTorque(dirX1, dirY1, dirZ1);
        
        GameObject dice2Instance = Instantiate(dicePrefab, diceThrowerTwo.position, Quaternion.identity);
        float dirX2 = Random.Range(0, 500);
        float dirY2 = Random.Range(0, 500);
        float dirZ2 = Random.Range(0, 500);
        dice2Instance.GetComponent<Rigidbody>().AddForce(-transform.right * 350);
        dice2Instance.GetComponent<Rigidbody>().AddTorque(dirX2, dirY2, dirZ2);
    }

    private void CalculateDiceOutput(int diceResult)
    {
        if (_diceOneRoll == 0)
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
            return;
        }
        _doublesRolled = 0;
        _diceOneRoll = 0;
        _diceTwoRoll = 0;
    }

    private bool RolledADouble()
    {
        return _diceOneRoll == _diceTwoRoll;
    }
}
