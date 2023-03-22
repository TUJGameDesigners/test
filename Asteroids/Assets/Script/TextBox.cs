using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class TextBox : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreamentCounter(int point) 
    {
        counter += point;
        counterText.text = counter.ToString();
    }
}
