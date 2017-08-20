using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    Behaviour[] componentsToDisable;

	// Use this for initialization
	void Start () {
	    if(!isLocalPlayer)
        {
            for(int i = 0; i < componentsToDisable.Length; i ++)
            {
                componentsToDisable[i].enabled = false;
            }
        }
	}

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
