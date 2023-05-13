using System.Collections.Generic;
using System.Linq;
using Commands;
using Interfaces;
using Tiles;
using UnityEngine;
using UnityEngine.UI;

public class PropertyManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager; // TODO: Clean this
    [SerializeField] private Button purchaseButton;
    private List<Tile> tiles = new();
    private Tile currentTile;

    private void Awake() => tiles.AddRange(FindObjectsOfType<Tile>());

    private void OnEnable()
    {
        purchaseButton.onClick.AddListener(PurchaseProperty);
        tiles.ForEach(tile => tile.OnTileLanded += ShowPurchaseButton_OnTileLanded);
        gameManager.OnTurnChanged += player => HidePurchaseButton();
    }

    private void OnDisable()
    {
        purchaseButton.onClick.RemoveListener(PurchaseProperty);
        tiles.ForEach(tile => tile.OnTileLanded -= ShowPurchaseButton_OnTileLanded);
        gameManager.OnTurnChanged -= player => HidePurchaseButton();
    }

    private void Start()
    {
        HidePurchaseButton();
    }

    private void PurchaseProperty()
    {
        Player currentPlayer = GameManager.Instance.ActivePlayer;
        //currentPlayer.BuyProperty(currentTile as IPurchasable);
        ICommand buyPropertyCommand = new BuyPropertyCommand(currentPlayer, currentTile as IProperty);
        buyPropertyCommand.Execute();
        //PlayerTurn turn = new PlayerTurn();
        //turn.AddCommand(buyPropertyCommand);
        HidePurchaseButton();
    }

    private void ShowPurchaseButton_OnTileLanded(Tile tile)
    {
        if (tile is IPurchasable purchasable && !purchasable.HasOwner())
        {
            ShowPurchaseButton();
            currentTile = tile;
        }
    }

    private void ShowPurchaseButton()
    {
        purchaseButton.gameObject.SetActive(true);
    }

    private void HidePurchaseButton()
    {
        purchaseButton.gameObject.SetActive(false);
    }
}
