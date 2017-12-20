using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Damage : NetworkBehaviour {

    [SerializeField]
    private float damage=30;
    [SerializeField]
    private float hp = 3;
    [SyncVar]
    private Vector3 nowPos;
	// Use this for initialization
	void Start () {
        nowPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (hp <= 0)
        {
            Destroyed();
        }
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
        {
            Status stat = other.gameObject.GetComponent<Status>();
            stat.Damages(damage);
            hp -= 1;
        }
    }
    void Destroyed()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
