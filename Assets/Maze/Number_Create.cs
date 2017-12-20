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

    [SyncVar]
    int number1;
    int number2;
    int number3;

    [SyncVar]//問題の色の順番
    public int arrayColor1;
    public int arrayColor2;
    public int arrayColor3;
    [SyncVar]//問題の演算子の順番
    public int arrayOperator1;
    public int arrayOperator2;

    // Use this for initialization
    void Start () {

        Random_num();

        Create_num(Number_pos1,Rand_num1,number1,1);
        Create_num(Number_pos2,Rand_num2,number2,2);
        Create_num(Number_pos3,Rand_num3,number3,3);
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

        number1 = Random.Range(11, 99);
        number2 = Random.Range(11, 99);
        number3 = Random.Range(11, 99);

        int[] arrayColor = { 1, 2, 3 };
        //色のランダム入れ替え
        for (int i = 0; i < arrayColor.Length; i++)
        {
            int j = Random.Range(0, arrayColor.Length - 1);
            int t = arrayColor[i];
            arrayColor[i] = arrayColor[j];
            arrayColor[j] = t;
        }

        arrayColor1 = arrayColor[0];
        arrayColor2 = arrayColor[1];
        arrayColor3 = arrayColor[2];

        arrayOperator1 = Random.Range(0, 1);
        arrayOperator2 = Random.Range(0, 1);
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
