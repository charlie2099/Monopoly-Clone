using System.Collections.Generic;
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
        [SerializeField] private TMP_Text tileText;
        [SerializeField] private TMP_Text playerTurnText;
        [SerializeField] private List<TMP_Text> playerBalancesText;

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
            playerTurnText.text = $"Turn: <color=red>{GameManager.Instance.ActivePlayer.Username}</color>"; 
            tileText.text = $"Tile: <color=green>{GameManager.Instance.Tiles[0].TileName}</color>";
        }
        
        private void Update()
        {
            // TODO: Clean up
            for (var i = 0; i < GameManager.Instance.PlayerCount; i++)
            {
                playerBalancesText[i].text = $"{GameManager.Instance.Players[i].Username}: <color=orange>{GameManager.Instance.Players[i].BankAccount.BalanceRemaining}</color>";
            }
        }

        private void UpdateUiOnTokenMoved(Tile tile)
        {
            tileText.text = $"Tile: <color=green>{tile.TileName}</color>";
        }
        
        private void UpdateUiOnTurnChanged(Player player)
        {
            playerTurnText.text = $"Turn: <color=red>{player.Username}</color>";
            tileText.text = $"Tile: <color=green>{player.Token.CurrentTile.TileName}</color>";
        }
    }
}
