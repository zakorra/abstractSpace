using System;
using System.Collections.Generic;
using UnityEngine;
using _Scripts.entities;

namespace _Scripts
{
    [Serializable]
    public struct Planets
    {
        public TileType TileType;
        public int amount;
    }
    
    public class GameSettings : MonoBehaviour
    {
        public GalaxySizeType GalaxySizeType;
        public GalaxyShapeType GalaxyShapeType;
        public ColonizablePlanetOddsType ColonizablePlanetOddsType;
        public SystemDistanceSizeType SystemDistanceSizeType;
        public HyperlaneCountType HyperlaneCountType;
        public CoreRessourceCountType CoreRessourceCountType;
        public ProgressiveRessourceCountType ProgressiveRessourceCountType;
        // public Planets[] PlanetList;

    }
}