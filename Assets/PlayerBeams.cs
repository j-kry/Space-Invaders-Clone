using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBeams : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed = 5;
    public int damage;
    public string target;
    public GameObject explosion;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);         
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == target)
        {
            
            Destroy(col.gameObject);
            Score.updateScore();
            Destroy(gameObject);
            GameObject expl = Instantiate(explosion, col.transform.position, Quaternion.identity);
            Destroy(expl, 0.3f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
