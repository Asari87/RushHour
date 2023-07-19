using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private EnemyController whatToSpawn;
    [SerializeField] private int numberOfLanes;
    [SerializeField] private int distanceBetweenLanes;

    [SerializeField] private float spawnInterval;
    private float timeSinceLastSpawn = 0;
 
    private ObjectPool<EnemyController> carPool;
    [SerializeField] private Color[] colorPool;
    private void Awake()
    {
        EnemyController.OnOutOfBounds += OnCarOutOfBounds;
        carPool = new ObjectPool<EnemyController>(CreateNewCar);
    }
    private void OnDestroy()
    {
        EnemyController.OnOutOfBounds -= OnCarOutOfBounds;
    }
    private EnemyController CreateNewCar()
    {
        return Instantiate(whatToSpawn, transform);

    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if(timeSinceLastSpawn > spawnInterval)
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0;
        }
    }

    private void SpawnEnemy()
    {
        int laneNumber = UnityEngine.Random.Range(0, numberOfLanes);
        EnemyController car = carPool.Get();
        car.transform.position = transform.position + Vector3.left * laneNumber * distanceBetweenLanes;
        car.SetColor(colorPool[UnityEngine.Random.Range(0, colorPool.Length)]);
        car.gameObject.SetActive(true);
    }

    public void OnCarOutOfBounds(EnemyController car)
    {
        car.gameObject.SetActive(false);
        carPool.Release(car);
    }
}
