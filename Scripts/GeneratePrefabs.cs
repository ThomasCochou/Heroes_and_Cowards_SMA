using UnityEngine;

public class GeneratePrefabs : MonoBehaviour 
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject heroe;
    public int heroesNumber;
    public GameObject coward;
    public int cowardsNumber;
    public bool threeDim = false;
    public bool free = false;
    public float agentSpeed = 100.0f;
    public float simuSpeed = 1.0f;
	public bool start;
	public bool isPaused = true;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
	
    }

	void OnGUI () 
	{
		if(isPaused == true)
		{
			// string nbH;
			GUI.contentColor = Color.black;

			GUI.Box(new Rect(Screen.width / 2 - 120 , Screen.height / 2 - 40, 250, 150), "", new GUIStyle {normal = new GUIStyleState {background = Texture2D.whiteTexture } } );

			GUI.Label(new Rect(Screen.width / 2 - 80, Screen.height / 2 - 20, 200, 20), "Cowards number = " );
			GUI.Label(new Rect(Screen.width / 2 + 40, Screen.height / 2 - 20, 200, 20), cowardsNumber.ToString());
			cowardsNumber = (int)GUI.HorizontalSlider(new Rect(Screen.width / 2 - 100, Screen.height / 2 , 200, 20),cowardsNumber, 0, 100);

			GUI.Label(new Rect(Screen.width / 2 - 80, Screen.height / 2 + 20, 200, 20), "Heroes number = " );
			GUI.Label(new Rect(Screen.width / 2 + 40, Screen.height / 2 + 20, 200, 20), heroesNumber.ToString());
			heroesNumber = (int)GUI.HorizontalSlider(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 40, 200, 20),heroesNumber, 0, 100);

			if(GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 60, 80, 40), "Continue"))
			{
				start = true;
			}
		}
	}

	// Update is called once per frame
	void Update()
	{
		if(start == true)
		{
			isPaused = false;

			Vector3 position3D;

			int i = 0;

			for (; i < heroesNumber; i++)
			{
				var randomValueX = Random.Range(0.0f, 50.0f);
				var randomValueY = Random.Range(0.0f, 50.0f);
				var randomValueZ = Random.Range(0.0f, 50.0f);

				if(threeDim)
				{
					position3D =  new Vector3(randomValueX,randomValueY, randomValueZ);
				}
				else
				{
					position3D =  new Vector3(randomValueX, 0.5f, randomValueZ);
				}
				GameObject clone = (GameObject)Instantiate(heroe,position3D, Quaternion.identity);
				clone.GetComponent<AgentBehavior>().id = i;
			}

			for (; i < heroesNumber + cowardsNumber; i++)
			{

				var randomValueX = Random.Range(0.0f, 50.0f);
				var randomValueY = Random.Range(0.0f, 50.0f);
				var randomValueZ = Random.Range(0.0f, 50.0f);

				if(threeDim)
				{
					position3D =  new Vector3(randomValueX,randomValueY, randomValueZ);
				}
				else
				{
					position3D =  new Vector3(randomValueX, 0.5f, randomValueZ);
				}
				GameObject clone = (GameObject)Instantiate(coward, position3D, Quaternion.identity);
				clone.GetComponent<AgentBehavior>().id = i;
			}  

			start = false; 
		}

	}
}