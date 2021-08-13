using Microsoft.Azure.CosmosRepository;
using Microsoft.Azure.CosmosRepository.Attributes;

namespace Website.Shared
{
    [Container("post-data")]
    [PartitionKeyPath("/type")]
    public abstract class Entity : Item
    {
        protected override string GetPartitionKeyValue() => Type;
    }
}