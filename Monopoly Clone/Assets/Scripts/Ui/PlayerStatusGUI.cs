using System;
using Tiles;
using UnityEngine;
using UnityEngine.UI;

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
            GameManager.Instance.OnTokenMoved += UpdateButtonVisibilityOnTokenMoved;
            //BoardMaster.Instance.DiceManager.OnDiceRolled += UpdateButtonVisibilityOnDiceRolled;
            //BoardMaster.Instance.DiceManager.OnDoubleRolled += UpdateButtonVisibilityOnDoublesRolled;
            GameManager.Instance.OnTurnChanged += UpdateButtonVisibilityOnTurnChanged;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnTokenMoved -= UpdateButtonVisibilityOnTokenMoved;
            //BoardMaster.Instance.DiceManager.OnDiceRolled -= UpdateButtonVisibilityOnDiceRolled;
            //BoardMaster.Instance.DiceManager.OnDoubleRolled -= UpdateButtonVisibilityOnDoublesRolled;
            GameManager.Instance.OnTurnChanged -= UpdateButtonVisibilityOnTurnChanged;
        }

        private void Start() => /*endTurnButton.GetComponent<Image>().color = Color.gray;*/endTurnButton.SetActive(false);
        
        private void UpdateButtonVisibilityOnTokenMoved(Tile tile)
        {
            endTurnButton.SetActive(true);
            //endTurnButton.GetComponent<Image>().color = Color.white;
        }

        private void UpdateButtonVisibilityOnDiceRolled(int diceRollOne, int diceRollTwo)
        {
            rollDiceButton.SetActive(false);
            //rollDiceButton.GetComponent<Image>().color = Color.grey;
        }

        public void UpdateButtonVisibilityOnDoublesRolled(int doublesRolled)
        {
            rollDiceButton.SetActive(true);
            endTurnButton.SetActive(false);
            //rollDiceButton.GetComponent<Image>().color = Color.white;
            //endTurnButton.GetComponent<Image>().color = Color.gray;
        }
        
        private void UpdateButtonVisibilityOnTurnChanged(Player player)
        {
            rollDiceButton.SetActive(true);
            endTurnButton.SetActive(false);
            //rollDiceButton.GetComponent<Image>().color = Color.white;
            //endTurnButton.GetComponent<Image>().color = Color.gray;
        }
    }
}
