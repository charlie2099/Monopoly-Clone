using System;
using Tiles;
using UnityEngine;

namespace Ui
{
    /// <summary>
    /// Responsible for rendering all interactive Ui elements
    /// (e.g. buttons).
    /// </summary>
    public class PlayerStatusGUI : MonoBehaviour
    {
        [SerializeField] private GameObject rollDiceButton;
        [SerializeField] private GameObject endTurnButton;
        
        private void OnEnable()
        {
            BoardMaster.Instance.OnPieceMoved += UpdateButtonVisibilityOnPieceMoved;
            BoardMaster.Instance.Dice.OnDiceRolled += UpdateButtonVisibilityOnDiceRolled;
            BoardMaster.Instance.Dice.OnDoubleRolled += UpdateButtonVisibilityOnDoublesRolled;
            BoardMaster.Instance.OnTurnChanged += UpdateButtonVisibilityOnTurnChanged;
        }

        private void OnDisable()
        {
            BoardMaster.Instance.OnPieceMoved -= UpdateButtonVisibilityOnPieceMoved;
            BoardMaster.Instance.Dice.OnDiceRolled -= UpdateButtonVisibilityOnDiceRolled;
            BoardMaster.Instance.Dice.OnDoubleRolled -= UpdateButtonVisibilityOnDoublesRolled;
            BoardMaster.Instance.OnTurnChanged -= UpdateButtonVisibilityOnTurnChanged;
        }

        private void Start() => endTurnButton.SetActive(false);
        
        private void UpdateButtonVisibilityOnPieceMoved(Tile tile)
        {
            endTurnButton.SetActive(true);
        }

        private void UpdateButtonVisibilityOnDiceRolled(int diceRollOne, int diceRollTwo)
        {
            rollDiceButton.SetActive(false);
        }

        public void UpdateButtonVisibilityOnDoublesRolled(int doublesRolled)
        {
            rollDiceButton.SetActive(true);
            endTurnButton.SetActive(false);
        }
        
        private void UpdateButtonVisibilityOnTurnChanged(Player player)
        {
            rollDiceButton.SetActive(true);
            endTurnButton.SetActive(false);
        }
    }
}
