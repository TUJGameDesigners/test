using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public TextBox textScript;
    public GameObject gameOverBox;
    public AudioSource shootSound;
    public new Rigidbody2D rigidbody { get; private set; }
    public Bullet bulletPrefab;

    public float thrustSpeed = 1f;
    public bool thrusting { get; private set; }

    public float turnDirection { get; private set; } = 0f;
    public float rotationSpeed = 0.1f;

    public float respawnDelay = 3f;
    public float respawnInvulnerability = 3f;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            turnDirection = 1f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            turnDirection = -1f;
        }
        else
        {
            turnDirection = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        if (thrusting)
        {
            rigidbody.AddForce(transform.up * thrustSpeed);
        }

        if (turnDirection != 0f)
        {
            rigidbody.AddTorque(rotationSpeed * turnDirection);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Asteroid" || collision.gameObject.tag == "Alien") {
                StartCoroutine("GameOverCo");
        }
    }

    IEnumerator GameOverCo() {
        gameOverBox.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        shootSound.Play();
        bullet.attachPlayer(gameObject);
        bullet.Project(transform.up);
    }

    public void IncreamentCounter(int point) {
        textScript.IncreamentCounter(point);
    }
}
