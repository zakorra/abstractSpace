using System;
using System.Collections.Generic;
using TMPro;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using _Scripts.entities;

namespace _Scripts.systems
{
    public class GameResourcesSystem : JobComponentSystem
    {
        struct GameResourceJob : IJobProcessComponentData<GameResourceData, GameTimeData>
        {
            public float deltaTime;
            public float timeScale;
            
            public void Execute(ref GameResourceData gameResourceData, ref GameTimeData gameTimeData)
            {
                //CalculateTimeAndFireEvent(data, deltaTime, timeScale);
                gameResourceData.Amount++;
            }

        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            GameResourceJob gameResourceJob = new GameResourceJob
            {
                deltaTime = Time.deltaTime,
                timeScale = Time.timeScale
            };

            JobHandle jobHandle = gameResourceJob.Schedule(this, 64, inputDeps);
            return jobHandle;
        }

        protected override void OnCreateManager(int capacity)
        {
            base.OnCreateManager(capacity);
        }

        protected override void OnStartRunning()
        {
            base.OnStartRunning();
        }
        
        
        private void UpdateResource (GameResourceData data)
        {
            /*
            foreach (var entity in GetEntities<GameResourceComponent>())
            {
                FoodText.text = "" + FormatRessource(entity.GameResourceEntity.Food);
                EnergyCreditsText.text = "" + FormatRessource(entity.GameResourceEntity.EnergyCredits);
                ResearchText.text = "" + FormatRessource(entity.GameResourceEntity.Research);
                
                entity.GameResourceEntity.Food += entity.GameResourceEntity.FoodGeneration;   
                entity.GameResourceEntity.EnergyCredits += entity.GameResourceEntity.EnergyCreditsGeneration;   
                entity.GameResourceEntity.Research += entity.GameResourceEntity.ResearchGeneration;   
            }
            */
        }
    }
}
