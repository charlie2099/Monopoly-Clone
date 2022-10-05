using Tiles;
using UnityEngine;
using UnityEngine.Serialization;

public class Piece : MonoBehaviour
{
    [SerializeField] private PieceData pieceData;
    [FormerlySerializedAs("currentTile")] [SerializeField] private PropertyTile currentPropertyTile;
    
    private void Start()
    {
        GetComponent<MeshRenderer>().material.color = pieceData.colour;
    }

    public string PieceName() => pieceData.name;
    public Tile CurrentTile() => currentPropertyTile;
}
