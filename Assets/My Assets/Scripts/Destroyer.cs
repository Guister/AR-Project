using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public static int objectsPassed = 0;
    public static bool pause = false;
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
            Debug.Log("games over");
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Destroyer")
        {
            Destroy(gameObject);
            Destroy(transform.parent.gameObject);

            objectsPassed++;
        }
    }
}