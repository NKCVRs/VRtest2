using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemyGenerator : NetworkBehaviour
{

    public GameObject [] Enemy_prefab = new GameObject[4];

    // Use this for initialization
    void Start () {

        CmdCreateEnemy();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    [Command]
    void CmdCreateEnemy()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject obj = (GameObject)Instantiate(Enemy_prefab[i], new Vector3(1.0f,1.5f,1.0f), transform.rotation);
            NetworkServer.Spawn(obj);
        }
    }
}
