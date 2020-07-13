using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig WaveConfiguration;
    List<Transform> waypoints;
    float enemySpeed;

    int waypointindex = 0;

    public void SetWaveConfig(WaveConfig currentWave)
    {
        this.WaveConfiguration = currentWave;
    }

    private void Start()
    {
        waypoints = WaveConfiguration.getWayPoints();
        enemySpeed = WaveConfiguration.getEnemyMoveSpeed();
        transform.position = waypoints[waypointindex].transform.position;
    }

    private void Update()
    {
        if (waypointindex < waypoints.Count)
        {
            var targetPos = waypoints[waypointindex].transform.position;
            var moveFrame = Time.deltaTime * enemySpeed;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, moveFrame);
            if(transform.position == targetPos)
            {
                waypointindex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
