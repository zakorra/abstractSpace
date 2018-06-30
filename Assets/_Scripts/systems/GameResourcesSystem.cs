using System;
using System.Collections.Generic;
using TMPro;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;
using Unity.Entities;
using _Scripts.entities;

namespace _Scripts.systems
{
    public class GameResourcesSystem : ComponentSystem
    {
        private Text CurrentDateText;
		
        private Text FoodText;
        private Text EnergyCreditsText;
        private Text ResearchText;
	
        private Text FoodGenerationText;
        private Text EnergyCreditsGenerationText;
        private Text ResearchGenerationText;
        
        private DateTime _myDate;
        private float _currentTime;

        public event EventHandler NewMonth;

        private struct GameResourceComponent
        {
            public GameResourceEntity GameResourceEntity;
        }

        protected override void OnStartRunning()
        {
            base.OnStartRunning();
        
            CurrentDateText = GameObject.Find("CounterText").GetComponent<Text>();
            
            FoodText = GameObject.Find("FoodText").GetComponent<Text>();
            EnergyCreditsText = GameObject.Find("EnergyCreditsText").GetComponent<Text>();
            ResearchText = GameObject.Find("ResearchText").GetComponent<Text>();
		
            FoodGenerationText = GameObject.Find("FoodGenerationText").GetComponent<Text>();
            EnergyCreditsGenerationText = GameObject.Find("EnergyCreditsGenerationText").GetComponent<Text>();
            ResearchGenerationText = GameObject.Find("ResearchGenerationText").GetComponent<Text>();
            
            _myDate = new DateTime(2300, 01, 01);
            _currentTime = 0;

            CurrentDateText.text = GetTime();
        }

        protected override void OnUpdate()
        {
            CalculateTimeAndFireEvent();
        }

        private void CalculateTimeAndFireEvent()
        {
            _currentTime += Time.deltaTime * Time.timeScale;
            
            if (_currentTime > 1)
            {
                var oldMonth = _myDate.Month;
                _myDate = _myDate.AddDays(1);

                if (oldMonth != _myDate.Month)
                {
                    OnNewMonth(new EventArgs());
                }
                _currentTime--;
                
                CurrentDateText.text = GetTime();
            }
        }
        
        protected virtual void OnNewMonth(EventArgs e)
        {
            UpdateResource();
        }
        
        
        private void UpdateResource ()
        {
            foreach (var entity in GetEntities<GameResourceComponent>())
            {
                FoodText.text = "" + FormatRessource(entity.GameResourceEntity.Food);
                EnergyCreditsText.text = "" + FormatRessource(entity.GameResourceEntity.EnergyCredits);
                ResearchText.text = "" + FormatRessource(entity.GameResourceEntity.Research);
                
                entity.GameResourceEntity.Food += entity.GameResourceEntity.FoodGeneration;   
                entity.GameResourceEntity.EnergyCredits += entity.GameResourceEntity.EnergyCreditsGeneration;   
                entity.GameResourceEntity.Research += entity.GameResourceEntity.ResearchGeneration;   
            }
        }
        
        private string GetTime()
        {
            return _myDate.ToString("d");
        }
        
        private string FormatRessource(int res)
        {
            string prefix = "";
            if (res > 0)
                prefix = "+";

            return " (" + prefix + res.ToString() + ")";
        }

        
    }
}
