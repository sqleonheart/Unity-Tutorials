using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    private AudioSource playerAudio;
    private AudioSource backgroundMusic;
    public AudioClip crashSound;
    public AudioClip jumpSound;
    public ParticleSystem explosionParticles;
    public ParticleSystem stepDirt;
    public float jumpForce = 10f;
    public float gravityModifier;
    public bool isGrounded = true;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        backgroundMusic = Camera.main.GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            anim.SetTrigger("Jump_trig");
            stepDirt.Stop();
            playerAudio.PlayOneShot(jumpSound, 1f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            stepDirt.Play();
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 1);
            explosionParticles.Play();
            stepDirt.Stop();
            playerAudio.PlayOneShot(crashSound);
            backgroundMusic.Stop();
        }
    }
}
