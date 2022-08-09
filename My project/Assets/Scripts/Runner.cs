using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    public float jumpForce = 10f;

    public float gravityModifier = 1f;

    protected Rigidbody myRigidbody;
    protected Animator runnerAnim;

    public AudioSource runnerAudio;

    protected float prepareDistance;
    
    public bool isOnGround = true;

    public float baseSpeed = 5f;

    // Start is called before the first frame update

    protected void Jump()
    {
        runnerAudio.PlayOneShot(runnerAudio.clip);
        //myRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        myRigidbody.velocity = Vector3.up * jumpForce;
        isOnGround = false;
    }

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        runnerAnim = GetComponent<Animator>();
        runnerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }
    
    protected void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Obstacle") && isOnGround && !GameManager.Instance.isGameOver)
        {
            Jump();
        }
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !GameManager.Instance.isGameOver)
        {
            isOnGround = true;
            //dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            //playerAudio.PlayOneShot(crashSound, 1.0f);
            //dirtParticle.Stop();
            //explosionParticle.Play();
            GameManager.Instance.GameOver();
            Destroy(gameObject);
            //Debug.Log("Game Over!");
            //playerAnim.SetBool(DeathB, true);
            //playerAnim.SetInteger(DeathTypeINT, 1);
        }
    }

}
