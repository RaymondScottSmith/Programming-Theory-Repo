using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : Runner
{

    private int numberOfJumps = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle")
            && (isOnGround || numberOfJumps < 2))
        {
            numberOfJumps++;
            Jump();
        }
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && IsGameRunning())
        {
            isOnGround = true;
            numberOfJumps = 0;
            //dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            //playerAudio.PlayOneShot(crashSound, 1.0f);
            //dirtParticle.Stop();
            //explosionParticle.Play();
            GameManager.Instance.GameOverWin();
            Destroy(gameObject);
            Debug.Log("Game Over!");
            //playerAnim.SetBool(DeathB, true);
            //playerAnim.SetInteger(DeathTypeINT, 1);
        }
    }
}
