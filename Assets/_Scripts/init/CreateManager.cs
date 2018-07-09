using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using _Scripts;
using _Scripts.entities;

public class CreateManager : MonoBehaviour {

	public Button NewGameButton;
	
	public Dropdown dropdownGalaxySize;
	public Dropdown dropdownGalaxyShape;

	public GameSettings GameSettings;
	
	// Use this for initialization
	void Start()
	{
		List<Dropdown.OptionData> galaxySizeTypes = Enum.GetValues(typeof(GalaxySizeType))
			.Cast<GalaxySizeType>()
			.Select(v => new Dropdown.OptionData(v.ToString()))
			.ToList();

		Dropdown.OptionData a;
		dropdownGalaxySize.options = galaxySizeTypes;
		
		NewGameButton.onClick.AddListener(delegate { OnCreateGame(); });

	}
	
	public void OnCreateGame()
	{
		var gameSettings = GameSettings.GetComponent<GameSettings>();
		gameSettings.GalaxySizeType = (GalaxySizeType) Enum.ToObject(typeof(GalaxySizeType), dropdownGalaxySize.value);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
