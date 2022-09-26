using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    bool gameState = false;
    public float delay = 1;
    public GameObject completeLevelUI;
    public GameObject speedUpUI;
    public GameObject slowDownUI;

    public void completeLevel(){
        completeLevelUI.SetActive(true);
    }

    public void speedUp()
    {
        slowDownUI.SetActive(false);
        speedUpUI.SetActive(true);
       
    }
    public void slowDown()
    {
        speedUpUI.SetActive(false);
        slowDownUI.SetActive(true);
    }
    public void EndGame()
    {
        if (gameState == false)
        {
            gameState = true;
            Debug.Log("Game Over");
            Invoke("Restart", delay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
