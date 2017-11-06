using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class SerialPortComponent : MonoBehaviour
{
	public string Port = "COM7";
	SerialPort serial;

	void Start ()
	{
		serial = new SerialPort (Port, 9600);
		serial.Open ();
	}

	void Update()
	{
		if (serial.IsOpen && GameManagerComponent.Instance.PlayerAvailable) {
			serial.WriteLine (GameManagerComponent.Instance.PlayerCamera.rotation.y.ToString ());
			Debug.Log (serial.ReadLine());
		}
	}
}
