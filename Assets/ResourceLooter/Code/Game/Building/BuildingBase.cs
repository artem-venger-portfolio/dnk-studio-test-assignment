using UnityEngine;

namespace ResourceLooter
{
    public abstract class BuildingBase : MonoBehaviour
    {
        public abstract void Initialize(Inventory inventory, IGameConfig config);
        public abstract void PutResourcesToInventory();
    }
}