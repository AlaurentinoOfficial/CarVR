using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Transform Camera;

	// Use this for initialization
	void Start () {
		GameManagerComponent.Instance.PlayerAvailable = true;
		GameManagerComponent.Instance.PlayerCamera = Camera;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
