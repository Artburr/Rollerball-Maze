using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
	public float movementSpeed = 10;
	private GameObject[] pauseObjects;

    private Rigidbody _rb;
	private bool allowMovement = false;
	private bool gameHasStarted = false;

    public GameObject[] PauseObjects { get => pauseObjects; set => pauseObjects = value; }

    // Start is called before the first frame update
    void Start()
    {
		Time.timeScale = 1;

		PauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");            //gets all objects with tag ShowOnPause

		_rb = gameObject.GetComponent<Rigidbody>();
    }

	void Update()
	{

		//uses the p button to pause and unpause the game
		if (Input.GetKeyDown(KeyCode.P))
		{
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			}
			else if (Time.timeScale == 0)
			{
				Debug.Log("high");
				Time.timeScale = 1;
				hidePaused();
			}
		}
	}

	public void showPaused()
	{
		foreach (GameObject g in PauseObjects)
		{
			g.SetActive(true);
		}
	}

	public void hidePaused()
	{
		foreach (GameObject g in PauseObjects)
		{
			g.SetActive(false);
		}
	}

	private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        _rb.AddForce(movement * movementSpeed);
    }

	public void GameHasStarted()
    {
		gameHasStarted = true;
    }

	public void ToggleCharacterMovement(bool _bool)
    {
		allowMovement = _bool;
		_rb.isKinematic = !_bool;
    }

	public void OnGameReset()
    {
		ToggleCharacterMovement(false);
		gameHasStarted = false;
    }
}
