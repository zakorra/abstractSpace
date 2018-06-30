using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _GameUI : MonoBehaviour {

	private static _GameUI _gameUi;
		
	void Awake(){
		
		DontDestroyOnLoad (this);
         
		if (_gameUi == null) {
			_gameUi = this;
		} else {
			Object.Destroy(gameObject);
		}
	}
	
	
}
