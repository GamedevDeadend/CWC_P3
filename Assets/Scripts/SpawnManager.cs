using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Obstacle;
    public GameObject SpawnCoordinates;
    public float StartDelay = 2;
    public float RepeatRate = 3;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacles", StartDelay, RepeatRate); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacles()
    {
        Instantiate(Obstacle, SpawnCoordinates.transform.position, Obstacle.transform.rotation);      
    }
}
