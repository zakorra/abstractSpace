using System;
using Unity.Collections;
using Unity.Entities;

namespace _Scripts.entities
{
    [Serializable]
    public struct TileData : IComponentData
    {
        public TileType TileType;
        public int amount;
        public long planetUUID;
    }
    
    public class TiletEntity : ComponentDataWrapper<TileData> {}
}