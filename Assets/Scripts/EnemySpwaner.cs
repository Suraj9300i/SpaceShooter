using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwaner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> WaveConfigs;
    [SerializeField] bool looping = false;

    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpwanAllWaves());
        }
        while (looping);
    }

    IEnumerator SpwanAllWaves()
    {
        for(int waveindex = 0; waveindex < WaveConfigs.Count; waveindex++)
        {
            WaveConfig currentWave = WaveConfigs[waveindex];
            yield return StartCoroutine(SpwanAllEnemies(currentWave));
        }
    }

    IEnumerator SpwanAllEnemies(WaveConfig CurrentWave)
    {
        for(int enemtCount = 0; enemtCount < CurrentWave.getNumberOfEnemies(); enemtCount++)
        {
            var newEnemy = Instantiate(CurrentWave.getEnemyPrefab(), CurrentWave.getWayPoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(CurrentWave);
            yield return new WaitForSeconds(CurrentWave.getTimeBetweenSpwan());
        }
    }
}
