using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class MenuMove : MonoBehaviour
{
    public GameObject prompt;
    public GameObject[] myChoices;
    public RectTransform myCursor;

    public Vector3 cursorOffset;
    public Vector3[] cursorPos;
    public Vector3 oriPos, noPos;
    bool inUseFlag = false, noFlag = false;
    int currChoice = 0;

    //public Question[] questions;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CursorMove();
        ChoiceSelect();
    }

    void CursorMove()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if (!inUseFlag)
            {
                if((Input.GetAxisRaw("Horizontal") > 0 && currChoice < myChoices.Length - 1 ||
                   Input.GetAxisRaw("Horizontal") < 0 && currChoice > 1) && noFlag == false)
                   //-1 to exclude no choice
                {
                    currChoice += (int)Input.GetAxisRaw("Horizontal");
                    myCursor.localPosition = cursorPos[currChoice];//myCursor.localPosition += Input.GetAxisRaw("Horizontal") * cursorOffset;
                }

                if (Input.GetAxisRaw("Vertical") < 0)
                {
                    noFlag = true;
                    myCursor.localPosition = noPos;
                }
                else if (Input.GetAxisRaw("Vertical") > 0)
                {
                    noFlag = false;
                    myCursor.localPosition = cursorPos[currChoice];//oriPos + cursorOffset * (currChoice - 1);
                }
                inUseFlag = true;
            }
        }
        else
        {
            inUseFlag = false;
        }
    }

    void ChoiceSelect()
    {
        if(Input.GetButtonDown("Submit"))
        {
            if (noFlag == true) currChoice = 0;
            StartCoroutine(choiceSelectCo());
        }
    }

    IEnumerator choiceSelectCo()
    {
        ChoiceMove choiceScript = myChoices[currChoice].GetComponent<ChoiceMove>();
        prompt.SetActive(false);
        choiceScript.ShowResponse();
        yield return new WaitForSeconds(3f);
        if (choiceScript.myNextObject == this.gameObject)
        {
            choiceScript.HideResponse();
            prompt.SetActive(true);
            myCursor.localPosition = oriPos;
            noFlag = false;
            currChoice = 1;
        }
        else
        {
            choiceScript.ShowNextQbject();
            this.gameObject.SetActive(false);
        }
    }

    /*[Serializable]
    public class Question
    {


        public Question(int myNum, GameObject[] myPrompts, GameObject[] myNextPrompts, RectTransform)
        {

        }
    }*/
}
