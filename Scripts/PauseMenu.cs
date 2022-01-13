using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

	public bool isPaused = false;
	private bool toggleThreeDim;
	private bool toggleFree;
	private float agentSliderSpeed;
	private float simuSliderSpeed;
	public float numberOfCowards;
	public float numberOfHeroes;

	// Start is called before the first frame update
	void Start()
	{
		toggleThreeDim = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GeneratePrefabs>().threeDim;
		toggleFree = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GeneratePrefabs>().free;
		agentSliderSpeed = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GeneratePrefabs>().agentSpeed;
		simuSliderSpeed = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GeneratePrefabs>().simuSpeed;
		numberOfCowards = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GeneratePrefabs>().cowardsNumber;
		numberOfHeroes = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GeneratePrefabs>().heroesNumber;
	}

	void OnGUI () 
	{
		if(isPaused)
		{
			GUI.contentColor = Color.black;
			GUI.Box(new Rect(Screen.width / 2 - 125 , Screen.height / 2 - 150, 250, 250), "", new GUIStyle {normal = new GUIStyleState { background = Texture2D.whiteTexture } } );

			toggleThreeDim = GUI.Toggle(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 140, 200, 20),toggleThreeDim, "	3D");

			toggleFree = GUI.Toggle(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 120, 200, 20),toggleFree, "	Free");
			
			
			GUI.Label(new Rect(Screen.width / 2 - 60, Screen.height / 2 - 100, 200, 20), "Agent speed = " );
			GUI.Label(new Rect(Screen.width / 2 + 40, Screen.height / 2 - 100, 200, 20), ((int)agentSliderSpeed).ToString() );
			agentSliderSpeed = GUI.HorizontalSlider(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 80, 200, 20),agentSliderSpeed, 1.0f, 5000.0f);

			GUI.Label(new Rect(Screen.width / 2 - 60, Screen.height / 2 - 60, 200, 20), "Simu speed = " );
			GUI.Label(new Rect(Screen.width / 2 + 40, Screen.height / 2 - 60, 200, 20), (simuSliderSpeed).ToString("0.##") );
			simuSliderSpeed = GUI.HorizontalSlider(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 40, 200, 20),simuSliderSpeed, 0.0f, 5.0f);

			GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GeneratePrefabs>().threeDim = toggleThreeDim;
			GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GeneratePrefabs>().free = toggleFree;
			GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GeneratePrefabs>().agentSpeed = agentSliderSpeed;
			GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GeneratePrefabs>().simuSpeed = simuSliderSpeed;

			if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 40, 80, 40), "Continue"))
			{
				isPaused = false;
			}

			if(GUI.Button(new Rect(Screen.width / 2 + 20, Screen.height / 2 + 40, 80, 40), "Restart"))
			{
				SceneManager.LoadScene("MainScene");
			}

			

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
			Time.timeScale = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GeneratePrefabs>().simuSpeed;
		}
	}
}
