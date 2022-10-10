using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour
{
    public static Dice Instance;
    public int DiceRollOutput => _diceOneRoll + _diceTwoRoll;
    
    [SerializeField] private TextMeshProUGUI diceRollText;
    private int _diceOneRoll;
    private int _diceTwoRoll;

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
        diceRollText.text = _diceOneRoll + " , " + _diceTwoRoll;
    }

    public bool RolledADouble()
    {
        if (_diceOneRoll == _diceTwoRoll)
        {
            return true;
        }
        return false;
    }
}
