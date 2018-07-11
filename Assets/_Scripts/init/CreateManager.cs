using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;
using _Scripts;
using _Scripts.entities;

public class CreateManager : MonoBehaviour {

	public Button NewGameButton;
	
	public Dropdown dropdownGalaxySize;
	public Dropdown dropdownGalaxyShape;


	public static EntityArchetype GalaxyArchetype;
	public static EntityArchetype GalaxySystemArchetype;
	public static EntityArchetype ShotSpawnArchetype;
	
	private GameSettings _gameSettings;

	private bool initialized = false;
	
	// Use this for initialization
	void Start()
	{
		List<Dropdown.OptionData> galaxySizeTypes = Enum.GetValues(typeof(GalaxySizeType))
			.Cast<GalaxySizeType>()
			.Select(v => new Dropdown.OptionData(v.ToString()))
			.ToList();

		Dropdown.OptionData a;
		dropdownGalaxySize.options = galaxySizeTypes;
		
		NewGameButton.onClick.AddListener( OnCreateGame);

		var settings = GameObject.Find("InitialGameSettings");
		_gameSettings = settings.GetComponent<GameSettings>();
	}
	
	private void OnCreateGame()
	{
		if (!initialized)
		{
			initialized = true;
			_gameSettings.GalaxyShapeType = (GalaxyShapeType) Enum.ToObject(typeof(GalaxyShapeType), dropdownGalaxyShape.value);
			_gameSettings.GalaxySizeType = (GalaxySizeType) Enum.ToObject(typeof(GalaxySizeType), dropdownGalaxySize.value);

			// Access the ECS entity manager
			var entityManager = World.Active.GetOrCreateManager<EntityManager>();

			/*GalaxySystemArchetype = entityManager.CreateArchetype(
				typeof(GameResourceData), typeof(GameTimeData), typeof(PlanetData),
				typeof(TileData));*/

			GalaxyArchetype = entityManager.CreateArchetype(typeof(GalaxyData));
			GalaxySystemArchetype = entityManager.CreateArchetype(typeof(GalaxySystemData));

			Entity galaxy = entityManager.CreateEntity(GalaxyArchetype);
			entityManager.SetComponentData(galaxy, new GalaxyData {GalaxyShapeType = _gameSettings.GalaxyShapeType, GalaxySizeType = _gameSettings.GalaxySizeType});

			for (int i = 0; i < 5; i++)
			{
				Entity galaxySystem = entityManager.CreateEntity(GalaxySystemArchetype);
				entityManager.SetComponentData(galaxySystem, new GalaxySystemData {planetNr = i});
			}
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
