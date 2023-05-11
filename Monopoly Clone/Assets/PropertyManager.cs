using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Tiles;
using UnityEngine;
using UnityEngine.UI;

public class PropertyManager : MonoBehaviour
{
    [SerializeField] private Button purchaseButton;
    private List<IPurchasable> purchasableTiles = new();
    private Tile currentTile;

    private void Awake()
    {
        purchaseButton.onClick.AddListener(PurchaseProperty);
        
        purchasableTiles = FindObjectsOfType<MonoBehaviour>().OfType<IPurchasable>().ToList();
        purchasableTiles.ForEach(purchasable => purchasable.OnPropertyTileLanded += ShowPurchaseButton_OnTileLanded);
    }
    
    private void Start()
    {
        purchaseButton.gameObject.SetActive(false);
    }

    private void PurchaseProperty()
    {
        Player currentPlayer = GameManager.Instance.ActivePlayer;
        currentPlayer.PurchaseProperty(currentTile as IPurchasable);
        //PurchaseCommand purchaseCommand = new PurchaseCommand();
        //purchaseCommand.Execute();
    }

    private void ShowPurchaseButton_OnTileLanded(Tile tile)
    {
        purchaseButton.gameObject.SetActive(true);
        currentTile = tile;
    }
}
