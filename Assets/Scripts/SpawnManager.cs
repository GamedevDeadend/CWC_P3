// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Obstacle;
    public GameObject SpawnCoordinates;
    public float StartDelay = 0;
    public float RepeatRate = 3;

    private PlayerController playercontroller;
    // Start is called before the first frame update
    void Start()
    {
        playercontroller  = GameObject.Find("FarmerCharacter").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacles", StartDelay, RepeatRate); 
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }

    void SpawnObstacles()
    {
        if(playercontroller.GameOver == false)
        {
            Instantiate(Obstacle, SpawnCoordinates.transform.position, Obstacle.transform.rotation);      
        }
    }
}
