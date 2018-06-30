using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEditor;

public class _GameManager : MonoBehaviour {

	private static _GameManager _gameManager;
	
	[SerializeField]
	private GameObject _ui;

	
	void Start()
	{
		Instantiate(_ui);
	}

	void Update()
	{
		
	}

	void Awake()
		{

			DontDestroyOnLoad(this);

			if (_gameManager == null)
			{
				_gameManager = this;
			}
			else
			{
				Destroy(gameObject);
			}
		}
}
