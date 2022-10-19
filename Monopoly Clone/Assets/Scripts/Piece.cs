using Tiles;
using UnityEngine;
using UnityEngine.AI;

public class Piece : MonoBehaviour
{
    public string PieceName => pieceData.name;
    public Tile CurrentTile => currentTile;
    public NavMeshAgent NavAgent { get => _navAgent; set => _navAgent = value; }
    
    [SerializeField] private PieceData pieceData;
    [SerializeField] private Tile currentTile;
    private NavMeshAgent _navAgent;

    private void Awake() => _navAgent = GetComponent<NavMeshAgent>();
    private void Start() => GetComponent<MeshRenderer>().material.color = pieceData.colour;
    public void SetCurrentTile(Tile tile) => currentTile = tile;
}
