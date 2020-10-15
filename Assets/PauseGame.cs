using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{

    private bool isPaused = false;

    void Update() {

        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) {


            //Add pause sound
            //Add pause graphic

            if(isPaused) {
                isPaused = false;
                Time.timeScale = 1;
            }
            else {
                isPaused = true;
                Time.timeScale = 0;
            }

        }

    }
}
