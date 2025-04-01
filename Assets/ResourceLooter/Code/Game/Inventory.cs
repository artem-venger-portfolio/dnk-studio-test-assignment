using System.Collections.Generic;

namespace ResourceLooter
{
    public class Inventory
    {
        private readonly Dictionary<ResourceType, int> _resources = new();

        public void Modify(ResourceType resource, int additionalValue)
        {
            _resources[resource] += additionalValue;
        }

        public int Get(ResourceType resource)
        {
            return _resources[resource];
        }
    }
}