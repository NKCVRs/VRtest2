using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Damage : NetworkBehaviour {

    [SerializeField]
    private int damage=30;
    public void setDamage(int Dam) { damage = Dam; }
    public int getDamage() { return damage; }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
