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
        //for (int i = 0; i < 4; i++)
        //{
        //    GameObject obj = (GameObject)Instantiate(Enemy_prefab[i], new Vector3(1.0f, 1.5f, 1.0f), transform.rotation);
        //    NetworkServer.Spawn(obj);
        //}

        GameObject obj = (GameObject)Instantiate(Enemy_prefab[0], new Vector3(1.0f, 0.6f, 1.0f), transform.rotation);
        NetworkServer.Spawn(obj);
        GameObject obj1 = (GameObject)Instantiate(Enemy_prefab[1], new Vector3(1.0f, 0.6f, 19.0f), transform.rotation);
        NetworkServer.Spawn(obj1);
        GameObject obj2 = (GameObject)Instantiate(Enemy_prefab[2], new Vector3(35.0f, 0.6f, 19.0f), transform.rotation);
        NetworkServer.Spawn(obj2);
        GameObject obj3 = (GameObject)Instantiate(Enemy_prefab[3], new Vector3(35.0f, 0.6f, 1.0f), transform.rotation);
        NetworkServer.Spawn(obj3);

        //for (int i = 1; i < 19; i++)
        //{
        //    GameObject obj3 = (GameObject)Instantiate(Enemy_prefab[3], new Vector3(1.0f, 0.6f, i), transform.rotation);
        //    NetworkServer.Spawn(obj3);
        //}
    }
}
