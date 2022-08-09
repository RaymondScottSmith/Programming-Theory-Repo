using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buck : Runner
{

    private float m_JumpAgainDelay = 0.25f;

    public float jumpAgainDelay
    {
        get { return m_JumpAgainDelay; }
        set
        {
            if (value < 0.0f)
            {
                Debug.LogError("Jump delay cannot be set to negative number");
            }
            else
            {
                m_JumpAgainDelay = value;
            }
        }
    }

    private bool isFalling = false;

    private void Update()
    {
        if (transform.position.y > 8.0f)
            isFalling = true;
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !GameManager.Instance.isGameOver)
        {
            isFalling = false;
            StartCoroutine(JumpDelay());
            //dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            //playerAudio.PlayOneShot(crashSound, 1.0f);
            //dirtParticle.Stop();
            //explosionParticle.Play();
            if (isFalling)
            {
                Destroy(collision.gameObject);
                return;
            }
            GameManager.Instance.GameOver();
            Destroy(gameObject);
            //playerAnim.SetBool(DeathB, true);
            //playerAnim.SetInteger(DeathTypeINT, 1);
        }
    }

    private IEnumerator JumpDelay()
    {
        yield return new WaitForSeconds(jumpAgainDelay);
        isOnGround = true;
    }
}
