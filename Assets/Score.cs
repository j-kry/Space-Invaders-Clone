using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static int score;
    public Text scoreTxt;

    private string[] cheatCode;
    private int index;


    void Start()
    {
        
        cheatCode = new string[] { "up", "up", "down", "down", "left", "right", "left", "right", "b", "a", "return" };
        index = 0;
    }

    void Update()
    {
        // Check if any key is pressed
        if (Input.anyKeyDown)
        {
            // Check if the next key in the code is pressed
            if (Input.GetKey(cheatCode[index]))
            {
                // Add 1 to index to check the next key in the code
                index++;
            }
            // Wrong key entered, we reset code typing
            else
            {
                index = 0;
            }
        }

        // If index reaches the length of the cheatCode string, 
        // the entire code was correctly entered
        if (index == cheatCode.Length)
        {
            SceneManager.LoadScene("test");
        }
    }

    public static void updateScore()
    {
        score += 100;

        if(score==2400)
        {
            SceneManager.LoadScene("Win");
        }
    }

    private void LateUpdate()
    {
        scoreTxt.text = "" + score;
    }
}
