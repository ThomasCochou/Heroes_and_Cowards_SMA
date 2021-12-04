using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

	public bool isPaused = false;
	private bool toggleThreeDim;
	private bool toggleFree;
	private float sliderSpeed;

	// Start is called before the first frame update
	void Start()
	{
		toggleThreeDim = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GeneratePrefabs>().threeDim;
		toggleFree = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GeneratePrefabs>().free;
		sliderSpeed = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GeneratePrefabs>().speed;
	}

	void OnGUI () 
	{
		if(isPaused)
		{
			GUI.contentColor = Color.black;
			GUI.Box(new Rect(Screen.width / 2 - 125 , Screen.height / 2 - 150, 250, 200), "", new GUIStyle {normal = new GUIStyleState { background = Texture2D.whiteTexture } } );

			if(GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2, 80, 40), "Continue"))
			{
				isPaused = false;
			}
			toggleThreeDim = GUI.Toggle(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 120, 200, 20),toggleThreeDim, "	3D");
			

			toggleFree = GUI.Toggle(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 90, 200, 20),toggleFree, "	Free");
			
			
			GUI.Label(new Rect(Screen.width / 2 - 40, Screen.height / 2 - 60, 200, 20), "Speed = " );
			GUI.Label(new Rect(Screen.width / 2 + 40, Screen.height / 2 - 60, 200, 20), ((int)sliderSpeed).ToString() );
			sliderSpeed = GUI.HorizontalSlider(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 30, 200, 20),sliderSpeed, 1.0f, 5000.0f);


			GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GeneratePrefabs>().threeDim = toggleThreeDim;
			GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GeneratePrefabs>().free = toggleFree;
			GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GeneratePrefabs>().speed = sliderSpeed;

		}
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			isPaused = !isPaused;
		}

		if(isPaused)
		{
			Time.timeScale = 0f;
		}
		else
		{
			Time.timeScale = 1f;
		}
	}
}
