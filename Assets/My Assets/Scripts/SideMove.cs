using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SideMove : MonoBehaviour {

    public float force;
    public float smoothing = 1f;
    private bool movedRight = false;
    private bool movedLeft = false;
    private bool moving = false;
    private int counter = 0;
    //public Transform target1;
   // public Transform target2;
    private Vector3 target1;
    private Vector3 target2;
    private float startTime;
    public static float timeDelta = 0.3f;
    private Vector3 Xvelocity;

	// Use this for initialization
	void Start () {
        Debug.Log("Hello");
        startTime = Time.time;
    }
	

    void FixedUpdate()
    {
        target1 = new Vector3(transform.position.x + force, transform.position.y, transform.position.z);
        target2 = new Vector3(transform.position.x - force, transform.position.y, transform.position.z);

        MoveRight();
        MoveLeft();
    }

    public void MoveRight()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || CrossPlatformInputManager.GetButtonDown ("Move Right"))
        {
            if (movedRight == false && moving == false && counter < 1)
            {
                counter++;
                this.StartCoroutine(SmoothMove(target1, timeDelta));
                Debug.Log("movedRight");
                Debug.Log(counter);

            }
        }
    }

    public void MoveLeft()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || CrossPlatformInputManager.GetButtonDown("Move Left"))
        {
            if (movedLeft == false && moving == false && counter > -1)
            {
                counter--;
                this.StartCoroutine(SmoothMove(target2, timeDelta));
                Debug.Log("movedLeft");
                Debug.Log(counter);
            }
        }
    }
    IEnumerator SmoothMove(Vector3 target, float delta)
    {
        moving = true;
        float close = 0.005f;
        float distance = (transform.position - target).magnitude;

        WaitForEndOfFrame wait = new WaitForEndOfFrame();

        while(distance >= close)
        {
            //Debug.Log("Moving");
            transform.position = Vector3.Lerp(transform.position, target, delta);
            yield return wait;

            distance = (transform.position - target).magnitude;
        }

        transform.position = target;

        moving = false;
        Debug.Log("Complete");
    }
}
