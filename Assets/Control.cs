using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Control : MonoBehaviour
{
    public AudioSource tickSource;
    public GameObject bullet;
    public Sprite shootingSprite;
    public Sprite idleSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    private Rigidbody2D rb2d;
    private SpriteRenderer sr;
    private bool isShooting = false;
    private int timer = 300;

    void Start() {

        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        tickSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(Input.GetAxis("Horizontal") * 10, Input.GetAxis("Vertical") * 0);

        if(Input.GetAxis("Horizontal") < 0f) {

            sr.sprite = leftSprite;

        }
        if (Input.GetAxis("Horizontal") > 0f) {

            sr.sprite = rightSprite;

        }
        if (Input.GetAxis("Horizontal") == 0f) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                isShooting = true;
                if (isShooting) {
                    tickSource.Play();
                    sr.sprite = shootingSprite;
                    GameObject shot = Instantiate(bullet, transform.position + transform.up, transform.rotation);
                    shot.GetComponent<Rigidbody2D>().AddForce(transform.up * 350);
                    Destroy(shot, 2f);
                }


            }
            if (Input.GetKeyUp(KeyCode.Space)) {
                isShooting = false;
                sr.sprite = idleSprite;
            }
        }
        

        if(transform.position.x > 9f) {

            rb2d.velocity = Vector2.zero;
            transform.position -= new Vector3(0.1f, 0, 0);

        }
        else if(transform.position.x < -9f) {

            rb2d.velocity = Vector2.zero;
            transform.position += new Vector3(0.1f, 0, 0);

        }
        
            
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if(collision.tag == "Enemy" || collision.tag == "Bullet") {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Score.score = 0;

        }

    }

}
