using Tiles;
using UnityEngine;

public class Token : MonoBehaviour
{
    public string PieceName => tokenData.name;
    public Tile CurrentTile => currentTile;

    [SerializeField] private TokenData tokenData;
    [SerializeField] private MeshRenderer model;
    [SerializeField] private Tile currentTile;
    
    private void Start() => model.material.color = tokenData.colour;
    public void SetCurrentTile(Tile tile) => currentTile = tile;
}
