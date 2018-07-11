using System;
using Unity.Entities;

namespace _Scripts.entities
{
    [Serializable]
    public struct GalaxyData : IComponentData
    {
        public GalaxySizeType GalaxySizeType;
        public GalaxyShapeType GalaxyShapeType;
    }
    
    public class GalaxyEntity : ComponentDataWrapper<GalaxyData> {}
}