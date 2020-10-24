using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class Win_Box : MonoBehaviour
{
    public UnityEvent resetGame;

    private void OnTriggerEnter(Collider other)
    {
            GameObject.Find("Player").SendMessage("Finish");
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
    }

    public void ResetGame()
    {
        resetGame.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}