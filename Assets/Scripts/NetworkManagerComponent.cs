using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManagerComponent : NetworkManager {
	public override void OnStartClient(NetworkClient conn)
    {
		//Instantiate (this.playerPrefab, transform.position, Quaternion.identity);
    }
}
