using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour {
    public float attack=34;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "player")
        {
            Status stat = col.gameObject.GetComponent<Status>();
            stat.Damages(attack);
        }
    }
}
