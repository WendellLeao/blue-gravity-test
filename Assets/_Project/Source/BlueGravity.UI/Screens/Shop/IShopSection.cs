using BlueGravity.Gameplay.Assembler;

namespace BlueGravity.UI.Screens.Shop
{
    public interface IShopSection
    {
        public void Dispose();
        
        public void Open();

        public void Close();

        public void PopulateGridLayoutGroup(BodyPartData[] bodyParts, bool hasNone);
    }
}