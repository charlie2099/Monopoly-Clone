using TMPro;
using UnityEngine;

public class TurnController : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI playerTurnText;
    private int _turnIndex;

    private void Start()
    {
        UpdateTurnText();
    }

    public void NextTurn()
    {
        if (!BoardMaster.Instance.PieceIsMoving)
        {
            if (!Dice.Instance.RolledADouble())
            {
                _turnIndex++;
                if (_turnIndex >= BoardMaster.Instance.Players.Count)
                {
                    _turnIndex = 0;
                }
                BoardMaster.Instance.SetActivePlayerByIndex(_turnIndex); 
            }
            Dice.Instance.DiceButton.SetActive(true);
            UpdateTurnText();
        }
    }
    
    private void UpdateTurnText()
    {
        playerTurnText.text = "Turn: <color=blue>" + BoardMaster.Instance.ActivePlayer.name + "</color>";
    }
}
