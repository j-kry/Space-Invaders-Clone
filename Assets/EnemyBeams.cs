using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeams : MonoBehaviour
{

    public int speed = 5;

    // Start is called before the first frame update
    void Start() {

        GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;

    }

    private void OnBecameInvisible() {

        Destroy(this.gameObject);

    }
    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.transform.tag == "Player") {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }

    }
}
