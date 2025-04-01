using System.Collections.Generic;

namespace ResourceLooter
{
    public class Inventory
    {
        private readonly Dictionary<ResourceType, int> _resources = new();

        public void Modify(ResourceType resource, int additionalValue)
        {
            AddResourceIfNeeded(resource);
            _resources[resource] += additionalValue;
        }

        public int Get(ResourceType resource)
        {
            AddResourceIfNeeded(resource);
            return _resources[resource];
        }

        private void AddResourceIfNeeded(ResourceType resource)
        {
            _resources.TryAdd(resource, value: 0);
        }
    }
}