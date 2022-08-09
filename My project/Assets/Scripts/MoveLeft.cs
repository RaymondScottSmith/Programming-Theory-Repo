using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 5f;

    //private PlayerController playerControllerScript;
    
    [SerializeField]
    private float leftBound = -15f;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = GameObject.FindObjectOfType<Runner>().baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GameManager.Instance.isGameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
            Destroy(gameObject);
        
    }
}
