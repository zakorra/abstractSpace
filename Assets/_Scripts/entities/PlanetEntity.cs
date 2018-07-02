using System;
using Unity.Collections;
using Unity.Entities;

namespace _Scripts.entities
{
    [Serializable]
    public struct PlanetData : IComponentData
    {
        public long uuid;
        public PlanetType PlanetType;
        public bool DeadPlanet;
    }

    public class PlanetEntity : ComponentDataWrapper<PlanetData> {}
}