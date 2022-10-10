using ScriptableObjects;
using UnityEngine;

namespace Tiles
{
    public abstract class Tile : MonoBehaviour
    {
        //[SerializeField] private TileType tileTypeData;
        public bool IsEmpty { get; set; }
        public int TileID { get; set; }
    }
}
