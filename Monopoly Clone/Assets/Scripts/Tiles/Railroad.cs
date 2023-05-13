using Interfaces;
namespace Tiles
{
    public class Railroad : Tile, IPurchasable
    {
        public void Purchase() {}

        public void Mortgage() {}

        public void SetOwner(Player player) {}

        public Player HasOwner() { return null; }
    }
}