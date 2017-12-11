using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {
    public float CharacterHP;
    [SerializeField]
    private float maxhp;

	// Use this for initialization
	void Start () {
        if (gameObject.tag == "Player")
        {
            CharacterHP = maxhp;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (CharacterHP <= 0)
        {
            Dead();
        }
	}
    public void Damages(float damage)
    {
        CharacterHP -= damage;
    }
    public void Dead()
    {

    }
}
