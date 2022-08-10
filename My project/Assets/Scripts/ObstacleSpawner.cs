using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject barrierPrefab;
    [SerializeField] private ParticleSystem spawnParticles;
    [SerializeField] private GameObject beamOfLight;
    [SerializeField] private AudioClip beam1;
    [SerializeField] private AudioClip beam2;
    
    
    private AudioSource ufoAudio;
    private Vector3 spawnPosition;

    private bool isWaiting;
    [SerializeField]
    private float spawnDelay;

    void Start()
    {
        spawnPosition = new Vector3(transform.position.x, 0f, 0f);
        ufoAudio = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) &&
            GameManager.Instance.gameState == GameState.Running
            && !isWaiting)
        {
            StartCoroutine(SpawnObstacle());

        }
    }

    private IEnumerator SpawnObstacle()
    {
        isWaiting = true;
        beamOfLight.SetActive(true);
        spawnParticles.Play();
        ufoAudio.PlayOneShot(beam1);
        yield return new WaitForSeconds(0.3f);
        ufoAudio.PlayOneShot(beam2);
        Instantiate(barrierPrefab, spawnPosition, barrierPrefab.transform.rotation);
        yield return new WaitForSeconds(0.2f);
        beamOfLight.SetActive(false);
        StartCoroutine(DelaySpawn());
    }

    private IEnumerator DelaySpawn()
    {
        yield return new WaitForSeconds(spawnDelay);
        isWaiting = false;
    }
}
