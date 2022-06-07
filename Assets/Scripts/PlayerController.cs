using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float ForceApplied;
    public float GravityMultiplier;

    public bool GameOver;

    public bool OnGround;

    private Animator PlayerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        OnGround = true;
        rb = GetComponent<Rigidbody>();
        PlayerAnimator = GetComponent<Animator>();
        Physics.gravity *= GravityMultiplier;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space ) && OnGround && GameOver == false)
        {
            rb.AddForce(Vector3.up* ForceApplied, ForceMode.Impulse);
            OnGround = false;
            PlayerAnimator.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            OnGround = true;
        }

        else if(other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Gameover");
            OnGround = true;
            GameOver = true;

            PlayerAnimator.SetBool("Death_b", true);
            PlayerAnimator.SetInteger("DeathType_int", 1);

        }
    } 
}
