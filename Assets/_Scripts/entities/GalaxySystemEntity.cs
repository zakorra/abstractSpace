using System;
using Unity.Entities;

namespace _Scripts.entities
{
    [Serializable]
    public struct GalaxySystemData : IComponentData
    {
        public int planetNr;
    }
    
    public class GalaxySystemEntity : ComponentDataWrapper<GalaxySystemData> {}
}