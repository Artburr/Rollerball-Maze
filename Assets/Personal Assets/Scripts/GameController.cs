using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject countdownScreen; 
    public GameObject UIScreen;
    public GameObject controlsScreen;
    public TextMeshProUGUI coundownText;

    public int countdownStart;

    public PlayerControls playerControls;

    // Start is called before the first frame update
    void Start()
    {
        startScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        startScreen.SetActive(false);
        StartCoroutine(Countdown(countdownStart));
    }

    IEnumerator Countdown(int _start)
    {
        coundownText.text = _start.ToString();
        countdownScreen.SetActive(true);

        yield return new WaitForSeconds(0.1f);

        for(int i = _start; i >= 0; i--)
        {
            coundownText.text = i.ToString();
            if (i < 1)
            {
                coundownText.text = "Start!";
            }
            yield return new WaitForSeconds(1.0f);
            yield return null;
        }
        countdownScreen.SetActive(false);
    }
}
