using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHealth : MonoBehaviour
{

    public int hp = 6;

    private SpriteRenderer sr;

    void Start() {

        sr = GetComponent<SpriteRenderer>();

    }

    void Update() {

        switch(hp) {

            case 5: sr.color = Color.green;
                break;
            case 4: sr.color = Color.blue;
                break;
            case 3:
                sr.color = Color.yellow;
                break;
            case 2:
                sr.color = Color.red;
                break;
            case 1:
                sr.color = Color.black;
                break;
            case 0: Destroy(gameObject);
                break;

        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if(collision.transform.tag == "Bullet" || collision.transform.tag == "PlayerBullet") {

            Destroy(collision.gameObject);
            hp--;

        }

    }

}
