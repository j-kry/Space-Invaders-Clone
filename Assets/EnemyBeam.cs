using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeam : MonoBehaviour
{
    public float timeBetweenShots;
    public float nextShot = -1;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        nextShot = Time.time + Random.Range(1, 10.0f);
        timeBetweenShots = Random.Range(3, 10.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time> nextShot)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextShot = Time.time + timeBetweenShots;
        }
    }
}
