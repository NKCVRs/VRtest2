using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {
    public float CharacterHP;
    [SerializeField]
    private float maxhp;
    private float time;
    private float Reg;
    private float HPReg;//体力自動回復量

	// Use this for initialization
	void Start () {
        HPReg = 1;
        if (gameObject.tag == "Player")
        {
            CharacterHP = maxhp;
        }
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time >= 15 && gameObject.tag == "Player")
        {//体力自動回復
            Reg -= Time.deltaTime;
            if (Reg <= 0.0)
            {
                Reg = 1.0f;
                CharacterHP += HPReg;
            }
        }
        if (CharacterHP <= 0)
        {
            Dead();
        }
	}
    public void Damages(float damage)
    {
        time = 0;
        CharacterHP -= damage;
    }
    public void Healing(float heal)//外的回復
    {
        CharacterHP += heal;
    }
    public void Dead()
    {
        Destroy(gameObject);
    }
}
