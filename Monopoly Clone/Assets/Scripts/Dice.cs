using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour
{
    public static Dice Instance;
    public int DiceRollOutput => _diceOneRoll+_diceTwoRoll;
    public GameObject DiceButton => diceRollButton;

    [SerializeField] private GameObject diceRollButton;
    [SerializeField] private TextMeshProUGUI diceRollText;
    private int _diceOneRoll;
    private int _diceTwoRoll;
    private int _doublesRolled;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void Roll()
    {
        _diceOneRoll = Random.Range(1, 7);
        _diceTwoRoll = Random.Range(1, 7);
        diceRollText.text = "Dice Roll: [" + _diceOneRoll + " + " + _diceTwoRoll + "]";
        
    }

    public bool RolledADouble()
    {
        if (_diceOneRoll == _diceTwoRoll)
        {
            _doublesRolled++;
            return true;
        }
        _doublesRolled = 0;
        return false;
    }
}
