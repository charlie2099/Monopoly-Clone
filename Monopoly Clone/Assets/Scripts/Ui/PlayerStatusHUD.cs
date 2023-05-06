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

        private void OnEnable()
        {
            GameManager.Instance.OnTokenMoved += UpdateUiOnTokenMoved;
            GameManager.Instance.OnTurnChanged += UpdateUiOnTurnChanged;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnTokenMoved -= UpdateUiOnTokenMoved;
            GameManager.Instance.OnTurnChanged -= UpdateUiOnTurnChanged;
        }

        private void Start()
        {
            playerTurnText.text = "Turn: <color=red>" + GameManager.Instance.ActivePlayer.Username + "</color>"; 
            tileText.text = "Tile: <color=red>" + GameManager.Instance.Tiles[0].TileName + "</color>";
        }

        private void UpdateUiOnTokenMoved(Tile tile)
        {
            tileText.text = "Tile: <color=red>" + tile.TileName + "</color>";
        }
        
        private void UpdateUiOnTurnChanged(Player player)
        {
            playerTurnText.text = "Turn: <color=red>" + player.Username + "</color>";
            tileText.text = "Tile: <color=red>" + player.Token.CurrentTile.TileName + "</color>";
        }
    }
}
