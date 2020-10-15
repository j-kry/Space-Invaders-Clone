using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed = 2;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 6)
        {
            transform.position = new Vector2(transform.position.x-0.5f, transform.position.y -0.5f);
            speed = -speed;
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        }
        else if (transform.position.x <= -6)
        {
            transform.position = new Vector2(transform.position.x + 0.5f, transform.position.y - 0.5f);
            speed = -speed;
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        }

        if(transform.position.y <= -4.2f) {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

    }

    private void OnBecameInvisible() {
        GetComponent<EnemyBeam>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Destroy(col.gameObject);
        }

        if(col.tag == "Wall") {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
}
