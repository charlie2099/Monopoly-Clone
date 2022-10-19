using System;
using Tiles;
using TMPro;
using UnityEngine;

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
            BoardMaster.Instance.OnPieceMoved += UpdateUiOnPieceMoved;
            BoardMaster.Instance.OnTurnChanged += UpdateUiOnTurnChanged;
            BoardMaster.Instance.Dice.OnDiceRolled += UpdateUiOnDiceRolled;
        }

        private void OnDisable()
        {
            BoardMaster.Instance.OnPieceMoved -= UpdateUiOnPieceMoved;
            BoardMaster.Instance.OnTurnChanged -= UpdateUiOnTurnChanged;
            BoardMaster.Instance.Dice.OnDiceRolled -= UpdateUiOnDiceRolled;
        }

        private void Start()
        {
            // TODO: Tidy
            playerTurnText.text = "Turn: <color=blue>" + BoardMaster.Instance.ActivePlayer.Username + "</color>"; 
            tileText.text = "Tile: <color=blue>" + BoardMaster.Instance.Tiles[0].name + "</color>";
        }

        private void UpdateUiOnPieceMoved(Tile tile)
        {
            tileText.text = "Tile: <color=blue>" + tile.name + "</color>";
        }
        
        private void UpdateUiOnTurnChanged(Player player)
        {
            playerTurnText.text = "Turn: <color=blue>" + player.Username + "</color>";
            diceRollText.text = "Dice Roll: ";
        }
        
        private void UpdateUiOnDiceRolled(int roll1, int roll2)
        {
            diceRollText.text = "Dice Roll: (<color=blue>" + roll1 + "+" + roll2 + "</color>)" + " [<color=blue>" + (roll1+roll2) + "</color>]";
        }
    }
}
