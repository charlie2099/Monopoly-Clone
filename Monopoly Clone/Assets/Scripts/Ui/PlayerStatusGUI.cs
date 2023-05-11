using Tiles;
using UnityEngine;

namespace Ui
{
    /// <summary>
    /// Responsible for setting the visibility of interactive Ui elements such as buttons
    /// </summary>
    public class PlayerStatusGUI : MonoBehaviour
    {
        [SerializeField] private GameObject rollDiceButton;
        [SerializeField] private GameObject endTurnButton;
        
        private void OnEnable()
        {
            GameManager.Instance.OnTokenMoved += UpdateButtonVisibilityOnTokenMoved;
            GameManager.Instance.OnTurnChanged += UpdateButtonVisibilityOnTurnChanged;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnTokenMoved -= UpdateButtonVisibilityOnTokenMoved;
            GameManager.Instance.OnTurnChanged -= UpdateButtonVisibilityOnTurnChanged;
        }

        private void Start() => endTurnButton.SetActive(false);
        
        private void UpdateButtonVisibilityOnTokenMoved(Tile tile)
        {
            endTurnButton.SetActive(true);
        }

        private void UpdateButtonVisibilityOnTurnChanged(Player player)
        {
            rollDiceButton.SetActive(true);
            endTurnButton.SetActive(false);
        }
    }
}
