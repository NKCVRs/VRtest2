using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Code_Input : MonoBehaviour {

    int Answer = 0;

    public GameObject AnswerText_obj;
    Text AnswerText_text;

    public GameObject MondaiImage1;
    public GameObject MondaiImage2;
    public GameObject MondaiImage3;

    public GameObject MondaiText1;
    public GameObject MondaiText2;

    public GameObject Number_Create_obj;
    Number_Create Number_Create_scr;

    // Use this for initialization
    void Start () {
        AnswerText_text = AnswerText_obj.GetComponent<Text>();
        Number_Create_scr = Number_Create_obj.GetComponent<Number_Create>();

        selectColor(MondaiImage1, Number_Create_scr.arrayColor1);
        selectColor(MondaiImage2, Number_Create_scr.arrayColor2);
        selectColor(MondaiImage3, Number_Create_scr.arrayColor3);

        Text Montxt1 = MondaiText1.GetComponent<Text>();
        if(Number_Create_scr.arrayOperator1 == 0)
        {
            Montxt1.text = "+";
        }
        else if (Number_Create_scr.arrayOperator1 == 1)
        {
            Montxt1.text = "-";
        }
        Text Montxt2 = MondaiText2.GetComponent<Text>();
        if (Number_Create_scr.arrayOperator2 == 0)
        {
            Montxt1.text = "+";
        }
        else if (Number_Create_scr.arrayOperator2 == 1)
        {
            Montxt1.text = "-";
        }
    }
	
	// Update is called once per frame
	void Update () {
        selectColor(MondaiImage1, Number_Create_scr.arrayColor1);
        selectColor(MondaiImage2, Number_Create_scr.arrayColor2);
        selectColor(MondaiImage3, Number_Create_scr.arrayColor3);
    }

    void selectColor(GameObject obj,int color_num)
    {
        Image img = obj.GetComponent<Image>();
        switch (color_num)
        {
            case 1:
                img.color = Color.red;
                break;
            case 2:
                img.color = Color.blue;
                break;
            case 3:
                img.color = Color.green;
                break;
        }
    }

    public void OnClick_Button0(int num)
    {
        if(Mathf.Abs(Answer) < 1)
        {
            Answer = num;
        }
        else
        {
            if (Answer > 0)
            {
                Answer = Answer * 10 + num;
            }
            else if(Answer < 0)
            {
                Answer = Answer * 10 - num;
            }      
        }

        AnswerText_text.text = Answer.ToString();
    }

    public void OnClick_ButtonEnter()
    {

    }
    public void OnClick_ButtonCancel()
    {
        if(Mathf.Abs(Answer) < 10)
        {
            Answer = 0;
        }
        else
        {
            Answer = Answer / 10;
        }

        AnswerText_text.text = Answer.ToString();
    }

    public void OnClick_ButtonMinus()
    {
        if(Answer > 0)
        {
            Answer *= -1;
        }

        AnswerText_text.text = Answer.ToString();
    }


    public void OnClick_ButtonPuls()
    {
        if (Answer < 0)
        {
            Answer *= -1;
        }

        AnswerText_text.text = Answer.ToString();
    }
}
