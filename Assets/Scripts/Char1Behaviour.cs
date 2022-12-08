using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Char1Behaviour : MonoBehaviour
{
    int sceneNum = 0, offset = 8;
    Rigidbody2D rb;
    Vector2 myV = Vector2.zero, jumpV = new Vector2(0, 10);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity += jumpV;
        }
    }

    void FixedUpdate() 
    {
        Vector2 currV = rb.velocity;
        Vector2 myV = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        myV *= offset;
        currV.x = myV.x;
        rb.velocity = currV;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Finish") SceneManager.LoadScene(sceneNum);
    }
}
