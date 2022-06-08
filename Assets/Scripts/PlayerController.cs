using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float ForceApplied;
    public float GravityMultiplier;
    public ParticleSystem explosion;
    public ParticleSystem Dirt;

    public bool GameOver;

    public bool OnGround;

    private Animator PlayerAnimator;

    public AudioClip jumpsound;
    public AudioClip crashsound;
    // Start is called before the first frame update
    private AudioSource PlayerAudio;

    void Start()
    {
        OnGround = true;
        rb = GetComponent<Rigidbody>();
        PlayerAnimator = GetComponent<Animator>();
        PlayerAudio = GetComponent<AudioSource>();
        Physics.gravity *= GravityMultiplier;
        Dirt.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space ) && OnGround && GameOver == false)
        {
            rb.AddForce(Vector3.up* ForceApplied, ForceMode.Impulse);
            OnGround = false;
            PlayerAudio.PlayOneShot(jumpsound);
            Dirt.Stop();
            PlayerAnimator.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            Dirt.Play();
            OnGround = true;
        }

        else if(other.gameObject.CompareTag("Obstacle"))
        {
            // Debug.Log("Gameover");
            OnGround = true;
            GameOver = true;
            Dirt.Stop();

            explosion.Play();
            PlayerAnimator.SetBool("Death_b", true);
            PlayerAnimator.SetInteger("DeathType_int", 1);
            PlayerAudio.PlayOneShot(crashsound);

        }
    } 
}
