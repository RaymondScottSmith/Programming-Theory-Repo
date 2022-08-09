using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject barrierPrefab;
    [SerializeField] private ParticleSystem spawnParticles;
    [SerializeField] private GameObject beamOfLight;
    private Vector3 spawnPosition;

    void Start()
    {
        spawnPosition = new Vector3(transform.position.x, 0f, 0f);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(SpawnObstacle());

        }
    }

    private IEnumerator SpawnObstacle()
    {
        beamOfLight.SetActive(true);
        spawnParticles.Play();
        yield return new WaitForSeconds(0.3f);
        Instantiate(barrierPrefab, spawnPosition, barrierPrefab.transform.rotation);
        yield return new WaitForSeconds(0.2f);
        beamOfLight.SetActive(false);
    }
}
