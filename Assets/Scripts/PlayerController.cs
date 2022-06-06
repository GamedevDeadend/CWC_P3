using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float ForceApplied;
    public float GravityMultiplier;

    public bool OnGround;
    // Start is called before the first frame update
    void Start()
    {
        OnGround = true;
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= GravityMultiplier;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space ) && OnGround)
        {
            rb.AddForce(Vector3.up* ForceApplied, ForceMode.Impulse);
            OnGround = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        OnGround = true;
    } 
}
