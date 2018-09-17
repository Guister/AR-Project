using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

    public AudioClip bg;
    private AudioSource source;
    bool played = false;

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
        //source.Play();
    }

    // Update is called once per frame
    void Update () {
        if (Spawner.clicked == true && played == false)
        {
            source.Play();
            played = true;
        }
        if(RestartMenu.lost == true)
        {
            source.Stop();
            played = false;
        }

    }
}
