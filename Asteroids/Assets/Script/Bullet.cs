using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    public float speed = 500f;
    public float maxLifetime = 10f;
    public GameObject playerObject;
    Player playerScript;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        
    }

    public void Project(Vector2 direction)
    {
        rigidbody.AddForce(direction * speed);

        Destroy(gameObject, maxLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Alien") {
            playerScript.IncreamentCounter(2);
        }
        else if(collision.gameObject.tag == "Asteroid") {
            playerScript.IncreamentCounter(1);
        }
        Destroy(gameObject);
    }

    public void attachPlayer(GameObject playerPar) {
        playerObject = playerPar;
        playerScript = playerObject.GetComponent<Player>();
    }
}
