using System;
using Unity.Entities;

namespace _Scripts.entities
{
    [Serializable]
    public struct GameResourceData : IComponentData
    {
        public GameResourceType GameResourceType;
        public float Amount;
        public float Generation;
    }

    public class GameResourceEntity : ComponentDataWrapper<GameResourceData> {}
}