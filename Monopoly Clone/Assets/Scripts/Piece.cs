using System.Collections;
using Tiles;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [SerializeField] private PieceData pieceData;
    [SerializeField] private Tile currentTile;
    
    private void Start() => GetComponent<MeshRenderer>().material.color = pieceData.colour;

    /*public void MoveTo(Vector3 target)
    {
        StartCoroutine(MovePiece(target));
    }*/

    /*private IEnumerator MovePiece(Vector3 target)
    {
        var speed = 1.0f * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position,target, speed);
        yield return new WaitForSeconds(5.0f);
    }*/

    public string PieceName => pieceData.name;
    public Tile CurrentTile => currentTile;
    public void SetCurrentTile(Tile tile) => currentTile = tile;
}
