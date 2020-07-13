using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] GameObject PathPrefab;
    [SerializeField] float timeBetweenSpwan = 0.5f;
    [SerializeField] float spwanRandomFactor = 0.3f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 3f;

    public GameObject getEnemyPrefab() { return EnemyPrefab; }
    public List<Transform> getWayPoints()
    {
        var WaveWayPoints = new List<Transform>();
        foreach(Transform child in PathPrefab.transform)
        {
            WaveWayPoints.Add(child);
        }
        return WaveWayPoints;
    }

    public float getTimeBetweenSpwan() { return timeBetweenSpwan; }

    public float getSpwanRandomFactor() { return spwanRandomFactor; }

    public float getEnemyMoveSpeed()
    {
        return moveSpeed;
    }

    public int getNumberOfEnemies()
    {
        return numberOfEnemies;
    }
}
