using System;
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
            BoardMaster.Instance.Dice.OnDiceRolled += UpdateButtonVisibilityOnDiceRolled;
            BoardMaster.Instance.Dice.OnDoubleRolled += UpdateButtonVisibilityOnDoublesRolled;
            BoardMaster.Instance.OnTurnChanged += UpdateButtonVisibilityOnTurnChanged;
        }

        private void OnDisable()
        {
            BoardMaster.Instance.Dice.OnDiceRolled -= UpdateButtonVisibilityOnDiceRolled;
            BoardMaster.Instance.Dice.OnDoubleRolled -= UpdateButtonVisibilityOnDoublesRolled;
            BoardMaster.Instance.OnTurnChanged -= UpdateButtonVisibilityOnTurnChanged;
        }

        private void Start() => endTurnButton.SetActive(false);

        private void UpdateButtonVisibilityOnDiceRolled(int diceRollOne, int diceRollTwo)
        {
            rollDiceButton.SetActive(false);
            endTurnButton.SetActive(true);
        }

        public void UpdateButtonVisibilityOnDoublesRolled(int doublesRolled)
        {
            rollDiceButton.SetActive(true);
            endTurnButton.SetActive(false);
        }
        
        private void UpdateButtonVisibilityOnTurnChanged(Player player)
        {
            endTurnButton.SetActive(false);
            rollDiceButton.SetActive(true);
        }
    }
}
