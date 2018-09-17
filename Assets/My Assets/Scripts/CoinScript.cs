using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

    public AudioClip coinSound;
    private AudioSource source;


    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
            Destroy(gameObject);
            ScoreScript.scoreValue += 500;      
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Destroyer")
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        //transform.Translate(Vector3.forward * -0.001f);
        transform.Rotate(0.1f, 0, 0);
    }
}
