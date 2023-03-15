using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceMove : MonoBehaviour
{
    public GameObject myResponse;
    public GameObject myNextObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowResponse()
    {
        myResponse.SetActive(true);
    }

    public void HideResponse()
    {
        myResponse.SetActive(false);
    }

    public void ShowNextQbject()
    {
        myNextObject.SetActive(true);
    }
}
