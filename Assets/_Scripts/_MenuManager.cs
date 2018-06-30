using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _MenuManager : MonoBehaviour {

	void Start () {
		Destroy (GameObject.Find("_GameManager"));
		Destroy (GameObject.Find("Canvas(Clone)"));
	}
}
