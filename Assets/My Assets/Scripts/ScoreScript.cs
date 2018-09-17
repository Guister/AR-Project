using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public static float scoreValue = 0;
    private float scorePerSecond = 100;
    Text score;

    // Use this for initialization
    void Start() {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {

    if (Spawner.clicked == true)
        { 
        scoreValue += scorePerSecond * Time.deltaTime;
        score.text = "Score: " + Mathf.RoundToInt(scoreValue);
        }
    }
}
