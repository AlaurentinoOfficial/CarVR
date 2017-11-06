using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerComponent : MonoBehaviour {

	public bool PlayerAvailable = false;
	public Transform PlayerCamera = null;

	public bool CameraAvailable = false;
	public RawImage CameraBackground = null;

	public static GameManagerComponent Instance { get; set; }

	// Use this for initialization
	void Start () {
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
