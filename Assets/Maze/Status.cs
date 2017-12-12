using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {
    public float CharacterHP;//体力
    [SerializeField]
    private float maxhp;//最大体力
    float time;
    float Regflg;
    float HPreg;//体力自動回復量

	// Use this for initialization
	void Start () {
        time = 0;
        HPreg = 1;
        if (gameObject.tag == "Player")
        {
            CharacterHP = maxhp;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale > 0)
        {//体力自動回復 HPreg
            time += Time.deltaTime;
            if (time >= 15&&gameObject.tag=="Player")
            {
                Regflg -= Time.deltaTime;
                if (Regflg <= 0.0)
                {
                    Regflg = 1.0f;
                    CharacterHP += HPreg;
                }
            }
        }
        if (CharacterHP <= 0)
        {
            Dead();
        }
        if (CharacterHP >= maxhp)
        {
            CharacterHP = maxhp;
        }
	}
    public void Damages(float damage)//被ダメージ処理
    {
        time = 0;
        CharacterHP -= damage;
    }
    public void Healing(float heal)//被回復処理　とりあえず
    {
        CharacterHP += heal;
    }
    public void Dead()
    {
        Destroy(gameObject);
    }
}
