using Tiles;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    /// <summary>
    /// Responsible for rendering all non-interactive Ui elements
    /// that relay information to the player about the current status
    /// of the game.
    /// </summary>
    public class PlayerStatusHUD : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI tileText;
        [SerializeField] private TextMeshProUGUI playerTurnText;
        [SerializeField] private TextMeshProUGUI diceRollText;

        private void OnEnable()
        {
            BoardMaster.Instance.OnTokenMoved += UpdateUiOnTokenMoved;
            BoardMaster.Instance.OnTurnChanged += UpdateUiOnTurnChanged;
            //BoardMaster.Instance.DiceManager.OnDiceRolled += UpdateUiOnDiceRolled;
        }

        private void OnDisable()
        {
            BoardMaster.Instance.OnTokenMoved -= UpdateUiOnTokenMoved;
            BoardMaster.Instance.OnTurnChanged -= UpdateUiOnTurnChanged;
            //BoardMaster.Instance.DiceManager.OnDiceRolled -= UpdateUiOnDiceRolled;
        }

        private void Start()
        {
            playerTurnText.text = "Turn: <color=red>" + BoardMaster.Instance.ActivePlayer.Username + "</color>"; 
            tileText.text = "Tile: <color=red>" + BoardMaster.Instance.Tiles[0].TileName + "</color>";
        }

        private void UpdateUiOnTokenMoved(Tile tile)
        {
            tileText.text = "Tile: <color=red>" + tile.TileName + "</color>";
        }
        
        private void UpdateUiOnTurnChanged(Player player)
        {
            playerTurnText.text = "Turn: <color=red>" + player.Username + "</color>";
            diceRollText.text = "Dice Roll: ";
        }
        
        private void UpdateUiOnDiceRolled(int roll1, int roll2)
        {
            diceRollText.text = "Dice Roll: (<color=red>" + roll1 + "+" + roll2 + "</color>)" + " [<color=red>" + (roll1+roll2) + "</color>]";
        }
    }
}
