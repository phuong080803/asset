using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnRate = 2.5f, spawnRadius = 200f;
    private float spawnTime = 0;
    public SpriteRenderer characterSR;

    void Start()
    {
        spawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime += Time.deltaTime;
        if(spawnTime>= spawnRate)
        {
            spawnEnemy();
            spawnTime = 0;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color= Color.yellow;
        Gizmos.DrawWireSphere(characterSR.transform.position, spawnRadius);
    }
    void spawnEnemy()
    {
        Vector2 spawnPosition = (Vector2)characterSR.transform.position + Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
