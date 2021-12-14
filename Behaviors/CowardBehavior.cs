using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
  
public class CowardBehavior : MonoBehaviour {  
  
    private Rigidbody me;
    private AgentBehavior agent;
    private Renderer render;

    // Use this for initialization  
    void Start () {  

        me = GetComponent<Rigidbody>();
        agent = GetComponent<AgentBehavior>();
        render = GetComponent<Renderer>();

        render.material.SetColor("_Color", new Color(255,0,0));
    }  
      
    // Update is called once per frame  
    void Update () {  

        float movementSpeed = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GeneratePrefabs>().agentSpeed;
        bool free = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GeneratePrefabs>().free;

        Vector3 friend_position = agent.friend.transform.position;
        Vector3 enemy_position = agent.transform.position;

        float new_x = friend_position.x + (friend_position.x - enemy_position.x)/2;
        float new_z = friend_position.z + (friend_position.z - enemy_position.z)/2;

        float new_y = friend_position.y + (friend_position.y - enemy_position.y)/2;

        Vector3 target = new Vector3(new_x, new_y, new_z);

        Vector3 goal = (target - transform.position).normalized;
        Vector3 direction = transform.position + goal * movementSpeed * Time.deltaTime;

        if(!free){
            if (direction.x >= 50){
                direction.x = 50;
            }
            if (direction.x <= 0){
                direction.x = 0;
            }
            if (direction.z >= 50) {
                direction.z = 50;
            }
            if (direction.z <= 0){
                direction.z = 0;
            }  
        }

        Quaternion rotation = Quaternion.LookRotation(goal, Vector3.forward);
        transform.rotation = rotation;


        if(GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GeneratePrefabs>().threeDim){
            if (direction.y >= 50) {
                direction.y = 50;
            }
            if (direction.y <= 0){
                direction.y = 0.5f;
            }

            me.MovePosition(direction);
        }
        else{
            direction.y = 0.5f;
            me.MovePosition(direction);
        }
    }  
}  