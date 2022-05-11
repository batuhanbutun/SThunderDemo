using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject player;
    [SerializeField] private ParticleSystem spawnParticle;
    [SerializeField] private GameStats _gameStats;
    private ParticleController _spawnedParticle;

    private bool isSpawned = false;
    private bool isSpawnedParticle = false;

    private float distance = 15f;

    private void Start()
    {
        if (player == null)
            player = GameObject.Find("Player");
    }

    void Update()
    {
        if (_gameStats.isGameActive)
        {
            if (Mathf.Abs(transform.position.z - player.transform.position.z) < 18f && !isSpawnedParticle)
            {
                _spawnedParticle = Instantiate(spawnParticle, transform.position, spawnParticle.transform.rotation).GetComponent<ParticleController>();
                isSpawnedParticle = true;
            }

            if (Mathf.Abs(transform.position.z - player.transform.position.z) < distance && !isSpawned)
            {
                if (_spawnedParticle)
                    _spawnedParticle.Die();
                Instantiate(enemy, transform.position, enemy.transform.rotation);
                isSpawned = true;
                Destroy(gameObject);
            }
        }
        
    }
}
