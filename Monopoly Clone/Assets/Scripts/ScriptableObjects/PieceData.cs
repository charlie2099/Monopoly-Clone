using UnityEngine;

[CreateAssetMenu(fileName = "PieceData", menuName = "ScriptableObjects/PieceData")]
public class PieceData : ScriptableObject
{
    public string name;
    public GameObject model;
    public Color colour;
    //public float startingCash;
}
