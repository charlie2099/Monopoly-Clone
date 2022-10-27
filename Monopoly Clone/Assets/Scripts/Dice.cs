using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour
{
    public event Action<int, int> OnDiceRolled;
    public event Action<int> OnDoubleRolled;
    public int DiceRollOutput => _diceOneRoll+_diceTwoRoll;
    public int DoublesRolled => _doublesRolled;
    public int DiceOneOutput
    {
        get => _diceOneRoll; 
        set => _diceOneRoll = value;
    }
    public int DiceTwoOutput
    {
        get => _diceTwoRoll; 
        set => _diceTwoRoll = value;
    }

    [SerializeField] private GameObject dicePrefab;
    [SerializeField] private Transform diceThrowerOne;
    [SerializeField] private Transform diceThrowerTwo;
    private Rigidbody _diceRb;
    private int _diceOneRoll;
    private int _diceTwoRoll;
    private int _doublesRolled;

    public void Roll() // called upon a click event via Roll Turn button
    {
        // Instantiating not ideal
        GameObject dice1Instance = Instantiate(dicePrefab, diceThrowerOne.position, Quaternion.identity);
        float dirX1 = Random.Range(0, 500);
        float dirY1 = Random.Range(0, 500);
        float dirZ1 = Random.Range(0, 500);
        dice1Instance.GetComponent<Rigidbody>().AddForce(-transform.right * 350);
        dice1Instance.GetComponent<Rigidbody>().AddTorque(dirX1, dirY1, dirZ1);
        
        /*GameObject dice2Instance = Instantiate(dicePrefab, diceThrowerTwo.position, Quaternion.identity);
        float dirX2 = Random.Range(0, 500);
        float dirY2 = Random.Range(0, 500);
        float dirZ2 = Random.Range(0, 500);
        dice2Instance.GetComponent<Rigidbody>().AddForce(-transform.right * 350);
        dice2Instance.GetComponent<Rigidbody>().AddTorque(dirX2, dirY2, dirZ2);*/
    }

    public void CalculateDiceOutput()
    {
        OnDiceRolled?.Invoke(_diceOneRoll, _diceTwoRoll);

        if (RolledADouble())
        {
            _doublesRolled++;
            OnDoubleRolled?.Invoke(_doublesRolled);
            return;
        }
        _doublesRolled = 0;
    }

    private bool RolledADouble()
    {
        if (_diceOneRoll == _diceTwoRoll)
        {
            return true;
        }
        return false;
    }
}
