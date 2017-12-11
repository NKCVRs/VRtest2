using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Damage : MonoBehaviour {

    [SerializeField]
    private float damage=30;

    public int HP = 3;
	// Use this for initialization
	void Start () {
        gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        if (HP <= 0)
        {
            Destroyed();
        }
	}
    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.name);
        if (col.gameObject.tag == "Player"|| col.gameObject.tag=="Enemy")
        {
            Status stat = col.gameObject.GetComponent<Status>();
            stat.Damages(damage);
            HP -= 1;
        }
    }
    void Destroyed()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
