namespace Interfaces
{
    public interface IPurchasable
    {
        public void Purchase();
        public void Mortgage();
        public void SetOwner(Player player);
        public Player HasOwner();
    }
}