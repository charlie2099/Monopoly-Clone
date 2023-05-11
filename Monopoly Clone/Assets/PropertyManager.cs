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
    private List<IPurchasable> purchasableTiles = new();
    private Tile currentTile;

    private void Awake()
    {
        purchaseButton.onClick.AddListener(PurchaseProperty);
        purchasableTiles = FindObjectsOfType<MonoBehaviour>().OfType<IPurchasable>().ToList();
    }

    private void OnEnable()
    {
        purchasableTiles.ForEach(purchasable => purchasable.OnPropertyTileLanded += ShowPurchaseButton_OnTileLanded);
        gameManager.OnTurnChanged += player => HidePurchaseButton();
    }

    private void OnDisable()
    {
        purchasableTiles.ForEach(purchasable => purchasable.OnPropertyTileLanded -= ShowPurchaseButton_OnTileLanded);
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
        ICommand buyPropertyCommand = new BuyPropertyCommand(currentPlayer, currentTile as IPurchasable);
        buyPropertyCommand.Execute();
        //PlayerTurn turn = new PlayerTurn();
        //turn.AddCommand(buyPropertyCommand);
        HidePurchaseButton();
    }

    private void ShowPurchaseButton_OnTileLanded(Tile tile)
    {
        var property = (IPurchasable)tile;
        if (!property.HasOwner())
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
