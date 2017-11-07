using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public Transform Camera;
	public RawImage Stream;
	public AspectRatioFitter Fit;

	public static Player Instance { get; set; }

	void Start ()
	{
		Instance = this;
	}

	void Update()
	{
		Camera.rotation = Quaternion.Euler (0f,
			Camera.rotation.eulerAngles.y < 30f ? 30f :
			Camera.rotation.eulerAngles.y > 180f ? 180f :
			Camera.rotation.eulerAngles.y, 0f);;
	}
}
