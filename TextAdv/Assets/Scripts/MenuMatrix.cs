using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class MenuMatrix : MonoBehaviour
{
    public GameObject prompt;
    public GameObject[] myChoices;
    public RectTransform myCursor;
    public Vector2[] cursorPos;
    public Vector2 oriPos;
    bool inUseFlag = false;
    //int rowNum = 0, clmNum = 0;
    int index = 0;
    public int rowMax, clmMax;

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
                /*if(clmMax == 0)
                {
                    if (Input.GetAxisRaw("Horizontal") > 0 && (index + 1) != (clmMax + 1) ||
                       Input.GetAxisRaw("Horizontal") < 0 && (index + 1) != 1)
                    {
                        index += (int)Input.GetAxisRaw("Horizontal");
                        myCursor.localPosition = cursorPos[index];
                    }
                }
                else*/
                if(clmMax != 0)
                {
                    if (Input.GetAxisRaw("Horizontal") > 0 && (index + 1) % (clmMax + 1) != 0 ||
                       Input.GetAxisRaw("Horizontal") < 0 && (index + 1) % (clmMax + 1) != 1)
                    {
                        index += (int)Input.GetAxisRaw("Horizontal");
                        myCursor.localPosition = cursorPos[index];
                    }
                }

                /*if(rowMax == 0)
                {
                    if (Input.GetAxisRaw("Vertical") > 0 && index != rowMax ||
                       Input.GetAxisRaw("Vertical") < 0 && index != 0)
                    {
                        index += (int)Input.GetAxisRaw("Vertical");
                        myCursor.localPosition = cursorPos[index];
                    }
                    inUseFlag = true;
                }
                else*/
                if(rowMax != 0)
                {
                    if (Input.GetAxisRaw("Vertical") < 0 && index / (clmMax + 1) != rowMax ||
                       Input.GetAxisRaw("Vertical") > 0 && index / (clmMax + 1) != 0)
                    {
                        index -= (int)Input.GetAxisRaw("Vertical") * (clmMax + 1);
                        myCursor.localPosition = cursorPos[index];
                    }
                    inUseFlag = true;
                }
            }
        }
        else
        {
            inUseFlag = false;
        }
    }

    void ChoiceSelect()
    {
        if (Input.GetButtonDown("Submit"))
        {
            StartCoroutine(choiceSelectCo());
        }
    }

    IEnumerator choiceSelectCo()
    {
        ChoiceMove choiceScript = myChoices[index].GetComponent<ChoiceMove>();
        prompt.SetActive(false);
        choiceScript.ShowResponse();
        yield return new WaitForSeconds(3f);
        choiceScript.HideResponse();
        prompt.SetActive(true);
        myCursor.localPosition = oriPos;
        index = 0;

        if (choiceScript.myNextObject != this.gameObject)
        {
            choiceScript.ShowNextQbject();
            this.gameObject.SetActive(false);
        }
    }
}
