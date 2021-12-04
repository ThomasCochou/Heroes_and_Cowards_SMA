using UnityEngine;
public class GeneratePrefabs : MonoBehaviour 
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject heroe;
    public int heroesNumber;
    public GameObject coward;
    public int cowardsNumber;
    public bool threeDim;
    public bool free;
    public float speed;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
    	
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
        
    }
}