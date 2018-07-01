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
                gameTimeData.CurrentTime += deltaTime * timeScale;
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

        protected override void OnStartRunning()
        {
            base.OnStartRunning();
        }


        private static void CalculateTimeAndFireEvent(GameResourceData data, float deltaTime, float timeScale)
        {
            _currentTime += deltaTime * timeScale;

            data.Amount += data.Generation * _currentTime;

            if (_currentTime > 1)
            {
                var oldMonth = _myDate.Month;
                _myDate = _myDate.AddDays(1);

                if (oldMonth != _myDate.Month)
                {
                    OnNewMonth(new EventArgs());
                }

                _currentTime--;

                //CurrentDateText.text = GetTime();
            }
        }

        private static void OnNewMonth(EventArgs e)
        {
            //UpdateResource();
        }
    }
}