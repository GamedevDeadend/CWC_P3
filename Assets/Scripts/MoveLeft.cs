using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float upperbound;
    private float speed = 20;

    private PlayerController playercontroller;
    // Start is called before the first frame update
    void Start()
    {
        playercontroller  = GameObject.Find("FarmerCharacter").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playercontroller.GameOver == false)
        {
            transform.Translate(Vector3.left* Time.deltaTime* speed); 
        }

        if(gameObject.CompareTag("Obstacle") && transform.position.x < upperbound)
        {
            Destroy(gameObject);
        }
    }
}
