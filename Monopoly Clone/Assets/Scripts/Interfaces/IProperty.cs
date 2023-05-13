using ScriptableObjects.PropertyData;

namespace Interfaces
{
    public interface IProperty : IPurchasable
    {
        public PropertyData PropertyData { get; }
        public void Upgrade();
        public void Downgrade();
    }
}
