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

    // ABSTRACTION
    protected void Jump()
    {
        runnerAudio.PlayOneShot(runnerAudio.clip);
        //myRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        myRigidbody.velocity = Vector3.up * jumpForce;
        isOnGround = false;
    }

    void Start()
    {
        Physics.gravity = GameManager.Instance.baseGravity;
        myRigidbody = GetComponent<Rigidbody>();
        runnerAnim = GetComponent<Animator>();
        runnerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }
    
    protected void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Obstacle")
            && isOnGround)
        {
            Jump();
        }
    }

    public bool IsGameRunning()
    {
        return GameManager.Instance.gameState == GameState.Running;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")
            && IsGameRunning())
        {
            isOnGround = true;
            //dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle") && IsGameRunning())
        {
            //playerAudio.PlayOneShot(crashSound, 1.0f);
            //dirtParticle.Stop();
            //explosionParticle.Play();
            GameManager.Instance.GameOverWin();
            Destroy(gameObject);
            //Debug.Log("Game Over!");
            //playerAnim.SetBool(DeathB, true);
            //playerAnim.SetInteger(DeathTypeINT, 1);
        }
    }

}
