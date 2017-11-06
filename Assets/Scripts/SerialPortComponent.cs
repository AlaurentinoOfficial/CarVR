using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class SerialPortComponent : MonoBehaviour
{
	SerialPort serial = new SerialPort("COM7", 9600);

	void Start ()
	{
		serial.Open ();
	}

	void Update()
	{
		if (serial.IsOpen) {
			serial.WriteLine (NetworkComponent.Camera.rotation.y.ToString ());
			Debug.Log (serial.ReadLine());
		}
	}
}
