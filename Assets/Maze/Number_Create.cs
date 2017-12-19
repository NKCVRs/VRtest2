using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Number_Create : NetworkBehaviour
{

    public GameObject Number_obj;
    public GameObject[] Number_pos1;
    public GameObject[] Number_pos2;
    public GameObject[] Number_pos3;

    [SyncVar]
    int Rand_num1;
    [SyncVar]
    int Rand_num2;
    [SyncVar]
    int Rand_num3;

    int number = 1995;
    // Use this for initialization
    void Start () {

        Random_num();

        Create_num(Number_pos1,Rand_num1,1234,1);
        Create_num(Number_pos2,Rand_num1, 5678,2);
        Create_num(Number_pos3,Rand_num1, 9012,3);

        //int num1 = Random.Range(0, Number_pos1.Length - 1);
        //int num2 = Random.Range(0, Number_pos2.Length - 1);
        //int num3 = Random.Range(0, Number_pos3.Length - 1);

        //GameObject obj1 = Instantiate(Number_obj, Number_pos1[num1].transform.position, Number_pos1[num1].transform.rotation);
        //GameObject obj2 = Instantiate(Number_obj, Number_pos2[num2].transform.position, Number_pos2[num2].transform.rotation);
        //GameObject obj3 = Instantiate(Number_obj, Number_pos3[num3].transform.position, Number_pos3[num3].transform.rotation);

        //obj1.transform.parent = this.transform;
        //obj2.transform.parent = this.transform;
        //obj3.transform.parent = this.transform;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    [Server]
    void Random_num()
    {
        Rand_num1 = Random.Range(0, Number_pos1.Length - 1);
        Rand_num2 = Random.Range(0, Number_pos2.Length - 1);
        Rand_num3 = Random.Range(0, Number_pos3.Length - 1);
    }

    //[Command]
    void Create_num(GameObject[] num_pos,int rand,int number,int col)
    {
        int num = rand;
        for(int i = 0;i < num_pos.Length;i++)
        {
            if(i == num)
            {
                GameObject obj = Instantiate(Number_obj, num_pos[num].transform.position, num_pos[num].transform.rotation);
                obj.transform.parent = this.transform;

                Text targetText = obj.GetComponent<Text>();
                targetText.text = number.ToString();

                switch (col)
                {
                    case 1:
                        targetText.color = Color.red;
                        break;
                    case 2:
                        targetText.color = Color.blue;
                        break;
                    case 3:
                        targetText.color = Color.green;
                        break;
                }
            }
            else
            {
                num_pos[i].SetActive(false);
            }
        }
    }

}
