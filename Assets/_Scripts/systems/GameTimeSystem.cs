using System;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;
using _Scripts.entities;

namespace _Scripts.systems
{
    public class GameTimeSystem : JobComponentSystem
    {
        private static DateTime _myDate;
        private static float _currentTime;

        struct GameTimeJob : IJobProcessComponentData<GameTimeData>
        {
            public float deltaTime;
            public float timeScale;

            public void Execute(ref GameTimeData gameTimeData)
            {
                gameTimeData.CurrentTime += deltaTime * timeScale * gameTimeData.TimeSpeed;
            }
        }
        
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            GameTimeJob gameTimeJob = new GameTimeJob
            {
                deltaTime = Time.deltaTime,
                timeScale = Time.timeScale
            };

            JobHandle jobHandle = gameTimeJob.Schedule(this, 64, inputDeps);
            return jobHandle;
        }
    }
}