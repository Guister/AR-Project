using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartMenu : MonoBehaviour {

    public GameObject restartMenuUI;
    public static bool lost = false;


    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            Debug.Log("games over");
            restartMenuUI.SetActive(true);
            Time.timeScale = 0;
            SideMove.timeDelta = 0;
            lost = true;
        }
    }
}
