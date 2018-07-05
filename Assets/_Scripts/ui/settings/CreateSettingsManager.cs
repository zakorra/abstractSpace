using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using _Scripts.entities;

public class CreateSettingsManager : MonoBehaviour {

	public Dropdown dropdownGalaxySize;
	
	// Use this for initialization
	void Start ()
	{
		List<Dropdown.OptionData> galaxySizeTypes = Enum.GetValues(typeof(GalaxySizeType))
			.Cast<GalaxySizeType>()
			.Select(v => new Dropdown.OptionData(v.ToString()))
			.ToList();

		Dropdown.OptionData a;
		dropdownGalaxySize.options = galaxySizeTypes;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
