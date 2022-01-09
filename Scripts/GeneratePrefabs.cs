using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using System.Linq;


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

	public int agentClustered;


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

	// Update is called once per frame
	void Update()
	{
		GameObject[] agents = GameObject.FindGameObjectsWithTag("agent");

		agentClustered = 0;

		List<List<int>> clusteredId = new List<List<int>>();

		foreach (GameObject agent in agents){

			if(agent.GetComponent<AgentBehavior>().clustered == true){
				agentClustered = agentClustered + 1;
			}

			clusteredId.Add(agent.GetComponent<AgentBehavior>().clusteredId);

		}

		WriteAgentClustered("agentClustered.txt", agentClustered, clusteredId);

		
	}

    static void WriteAgentClustered(string path, float agentClustered, List<List<int>> clusteredId)
    {
		var sr = File.CreateText(path);
		sr.WriteLine(agentClustered.ToString());

		foreach(List<int> idList in clusteredId){
			foreach(int id in idList){
				sr.Write(id);
			}
			sr.Write(";");
		}

		sr.Close();
    }

}