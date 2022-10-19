using ScriptableObjects;
using UnityEngine;

namespace Tiles
{
    public abstract class Tile : MonoBehaviour
    {
        [SerializeField] protected string tileName;
        /*[SerializeField] protected Tile previousTile;
        [SerializeField] protected Tile nextTile;*/
        public bool IsEmpty { get; set; }
        public int TileID { get; set; }
    }
}
