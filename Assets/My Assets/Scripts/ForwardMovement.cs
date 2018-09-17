using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMovement : MonoBehaviour {

    private float speed;
    public float acceleration;
    public float difficulty = 0;

	// Use this for initialization
	void Start () {
        speed = 2f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Run();
       
	}
    void Run()
    {
        difficulty = Spawner.obstaclesSpawned * 0.003f;

        speed += Time.deltaTime * acceleration + difficulty;
        if (speed > 15)
        {
            speed = 15;
        }
        GetComponent<Rigidbody>().AddForce(0, 0, -speed);
        //Debug.Log(Time.deltaTime);
        Debug.Log("speed: " + speed);
    }
}
