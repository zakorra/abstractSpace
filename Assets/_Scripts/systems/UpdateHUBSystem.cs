using System;
using System.Linq;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;
using _Scripts.entities;

namespace _Scripts.systems
{
    [AlwaysUpdateSystem]
    public class UpdateHUBSystem : ComponentSystem
    {
        public struct ResourceData
        {
            public int Length;
            [ReadOnly] public EntityArray Entity;
            [ReadOnly] public ComponentDataArray<GameResourceData> gameResourceDate;
        }
        
        public struct TimeData
        {
            public int Length;
            [ReadOnly] public EntityArray Entity;
            [ReadOnly] public ComponentDataArray<GameTimeData> gameTimeData;
        }

        private Text CurrentDateText;
        
        private Text FoodText;
        private Text EnergyCreditsText;
        private Text ResearchText;
        
        private Text FoodGenerationText;
        private Text EnergyCreditsGenerationText;
        private Text ResearchGenerationText;

        [Inject] private ResourceData _gameResourceData;
        [Inject] private TimeData _timeData;

        protected override void OnUpdate()
        {
            //FoodText.text = FormatRessource(_gameResourceData.Amount);

            for (int i = 0; i < _gameResourceData.Length; i++)
            {
                switch (_gameResourceData.gameResourceDate[i].GameResourceType)
                {
                    case GameResourceType.FOOD:
                        FoodText.text = FormatRessource(_gameResourceData.gameResourceDate[i]);
                        break;
                    case GameResourceType.ENERGY:
                        EnergyCreditsText.text = FormatRessource(_gameResourceData.gameResourceDate[i]);
                        break;
                    case GameResourceType.RESEARCH:
                        ResearchText.text = FormatRessource(_gameResourceData.gameResourceDate[i]);
                        break;
                    default:
                        break;
                }
            }

            for (int i = 0; i < _timeData.Length; i++)
            {
                CurrentDateText.text = FormatTime(_timeData.gameTimeData[i]);
            }

            
        }

        protected override void OnStartRunning()
        {
            base.OnStartRunning();
            
            CurrentDateText = GameObject.Find("CounterText").GetComponent<Text>();
            
            FoodText = GameObject.Find("FoodText").GetComponent<Text>();
            EnergyCreditsText = GameObject.Find("EnergyCreditsText").GetComponent<Text>();
            ResearchText = GameObject.Find("ResearchText").GetComponent<Text>();
		
            //FoodGenerationText = GameObject.Find("FoodGenerationText").GetComponent<Text>();
            //EnergyCreditsGenerationText = GameObject.Find("EnergyCreditsGenerationText").GetComponent<Text>();
            //ResearchGenerationText = GameObject.Find("ResearchGenerationText").GetComponent<Text>();
        }

        private string FormatRessource(GameResourceData data)
        {
            string prefix = "";
            if (data.Amount > 0)
                prefix = "+";

            //return  String.Format(" ( +" + prefix + "{0,0} + ", res);
            return  " " + prefix + data.Amount.ToString("N0") + " (" + data.Generation.ToString("N2") + ")";
        }
        
        private string FormatTime(GameTimeData dateTime)
        {
            DateTime date = new DateTime(dateTime.year, dateTime.month, dateTime.day).AddDays(dateTime.CurrentTime);
            return date.ToString("d");
        }
    }
}