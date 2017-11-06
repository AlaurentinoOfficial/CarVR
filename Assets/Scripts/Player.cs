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

	void LateUpdate()
	{
		Camera.rotation = Quaternion.Euler (0f, Mathf.Clamp(Camera.rotation.eulerAngles.y, 180, 90), 0f);;
	}
}
