using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    public float jumpForce = 10f;

    public float gravityModifier = 1f;

    protected Rigidbody myRigidbody;
    protected Animator runnerAnim;

    protected AudioSource runnerAudio;

    protected float prepareDistance;
    
    public bool isOnGround = true;
    // Start is called before the first frame update

    protected void Jump()
    {
        myRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;
    }

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        runnerAnim = GetComponent<Animator>();
        runnerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !GameManager.Instance.isGameOver)
        {
            isOnGround = true;
            //dirtParticle.Play();
        }
    }

}
