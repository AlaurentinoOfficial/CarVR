using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneCamera : MonoBehaviour
{
	bool camAvailable;
	WebCamTexture backCam;
	Texture defaultBg;

	public RawImage bg;
	public AspectRatioFitter fit;


	void Start ()
	{
		defaultBg = bg.texture;

		WebCamDevice[] devices = WebCamTexture.devices;
		camAvailable = devices.Length != 0;

		if (devices.Length == 0)
		{
			Debug.Log ("Não foi possível encontrar a camera do telefone!");
			return;
		}


		foreach(WebCamDevice cam in devices)
		{
			if (cam.isFrontFacing)
			{
				backCam = new WebCamTexture (cam.name, Screen.width, Screen.height);
				break;
			}
		}

		if (backCam == null)
		{
			Debug.Log ("Não foi possível conectar a câmera!");
			return;
		}

		backCam.Play ();
		bg.texture = backCam;
	}
	
	void Update ()
	{
		if (!camAvailable)
			return;

		float ratio = (float) backCam.width / (float) backCam.height;
		fit.aspectRatio = ratio;

		float scaleY = backCam.videoVerticallyMirrored ? -1f : 1f;
		bg.rectTransform.localScale = new Vector3(-1f, scaleY, 1f);

		int orient = -backCam.videoRotationAngle;
		bg.rectTransform.localEulerAngles = new Vector3 (0, 0, orient);
	}
}
