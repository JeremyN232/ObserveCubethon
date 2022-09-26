using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    bool gameState = false;
    public float delay = 1;
    public PlayerMovement pm;
    public GameObject completeLevelUI;
    public GameObject speedUpUI;
    public GameObject slowDownUI;
    public GameObject checkpointUI;
    public float currentTime = 0.0f;
    public float executedTime = 0.0f;
    public float textDelay = 2.5f;

    void OnEnable()
    {
        PlayerMovement.OnSpeed += speedUp;
        PlayerMovement.OnSlow += slowDown;
        PlayerMovement.OnScore += checkPoint;
    }
    void OnDisable()
    {
        PlayerMovement.OnSpeed -= speedUp;
        PlayerMovement.OnSlow -= slowDown;
        PlayerMovement.OnScore -= checkPoint;
    }

    public void completeLevel(){
        completeLevelUI.SetActive(true);
    }

    public void speedUp()
    {
        Debug.Log("speed up");
        pm.forwardForce = 4500f;
        slowDownUI.SetActive(false);
        speedUpUI.SetActive(true);
       
    }
    public void slowDown()
    {
        pm.forwardForce = 1000f;
        speedUpUI.SetActive(false);
        slowDownUI.SetActive(true);
    }

    public void checkPoint()
    {

        checkpointUI.SetActive(true);
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
