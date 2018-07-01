using System;
using Unity.Entities;

namespace _Scripts.entities
{
    [Serializable]
    public struct GameTimeData : IComponentData
    {
        public float CurrentTime;
        public float TimeSpeed;
        
        public int year;
        public int month;
        public int day;
    }

    public class GameTimeEntity : ComponentDataWrapper<GameTimeData> {}
}