using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBehavior : MonoBehaviour
{

	public int id;
    public GameObject friend;
	public GameObject enemy;
	public int friend_id;
	public int enemy_id;

    // Start is called before the first frame update
    void Start()
    {
	    GameObject[] agent = GameObject.FindGameObjectsWithTag("agent");

	    List<int> id_list = new List<int>();

	    for (int i = 0; i < agent.Length; i++){
            id_list.Add(agent[i].GetComponent<AgentBehavior>().id);
        }

        id_list.Remove(id);

	 	friend_id = id_list[Random.Range(0, id_list.Count)];

	 	id_list.Remove(friend_id);

	 	enemy_id = id_list[Random.Range(0, id_list.Count)];

	    for (int i = 0; i < agent.Length; i++)
		{
			if(agent[i].GetComponent<AgentBehavior>().id == friend_id){
				friend = agent[i];
			}
			if(agent[i].GetComponent<AgentBehavior>().id == enemy_id){
				enemy = agent[i];
			}
		}

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
