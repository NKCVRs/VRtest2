using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number_Create : MonoBehaviour {

    public GameObject Number_obj;
    public GameObject[] Number_pos1;
    public GameObject[] Number_pos2;
    public GameObject[] Number_pos3;

    int number = 1995;
    // Use this for initialization
    void Start () {

        int num1 = Random.Range(0, Number_pos1.Length - 1);
        int num2 = Random.Range(0, Number_pos2.Length - 1);
        int num3 = Random.Range(0, Number_pos3.Length - 1);

        GameObject obj1 = Instantiate(Number_obj, Number_pos1[num1].transform.position, Number_pos1[num1].transform.rotation);
        GameObject obj2 = Instantiate(Number_obj, Number_pos2[num2].transform.position, Number_pos2[num2].transform.rotation);
        GameObject obj3 = Instantiate(Number_obj, Number_pos3[num3].transform.position, Number_pos3[num3].transform.rotation);

        obj1.transform.parent = this.transform;
        obj2.transform.parent = this.transform;
        obj3.transform.parent = this.transform;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
