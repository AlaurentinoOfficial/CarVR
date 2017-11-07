using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

public class PhoneCamera : MonoBehaviour
{
	public string Port = "COM7";

	bool camAvailable;
	WebCamTexture backCam;
	Texture defaultBg;
	SerialPort serial;

	void Start ()
	{
		try
		{
			serial = new SerialPort (Port, 9600);
			serial.Open ();
		}
		catch(System.Exception ex)
		{}

		ConfigureTexture ();
	}
	
	void Update ()
	{
		UpdateAspectRatio ();

		if (serial.IsOpen)
			serial.WriteLine (Player.Instance.Camera.rotation.eulerAngles.y.ToString ());

		Debug.Log (Player.Instance.Camera.rotation.eulerAngles.y);
	}

	void ConfigureTexture()
	{
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
		Player.Instance.Stream.texture = backCam;
	}

	void UpdateAspectRatio()
	{
		if (!camAvailable)
			return;

		float ratio = (float) backCam.width / (float) backCam.height;
		Player.Instance.Fit.aspectRatio = ratio;

		float scaleY = backCam.videoVerticallyMirrored ? -1f : 1f;
		Player.Instance.Stream.rectTransform.localScale = new Vector3(-1f, scaleY, 1f);

		int orient = -backCam.videoRotationAngle;
		Player.Instance.Stream.rectTransform.localEulerAngles = new Vector3 (0, 0, orient);
	}
}
