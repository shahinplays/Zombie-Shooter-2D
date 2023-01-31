using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Wave
{
    public string waveName;
    public int noOFEnemies;
    public GameObject[] typeOfEnemies;
    public float spwanInterval;
}



public class WaveSpwaner : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spwanPoints;
    public Animator anim;

    public TMP_Text waveNameText;

    private Wave currentWave;
    private int currentWaveNumber;
    private float nextSpwanTime;

    private bool canSpwan = true;
    private bool canAnimate = false;

    void FixedUpdate()
    {
        currentWave = waves[currentWaveNumber];
        SpawnWave();

        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (totalEnemies.Length == 0)
        {
            if (currentWaveNumber + 1 != waves.Length)
            {
                if (canAnimate)
                {
                    waveNameText.text = waves[currentWaveNumber + 1].waveName;
                    anim.SetTrigger("WaveComplete");
                    canAnimate = false;
                }
                
            }
            if(currentWaveNumber == waves.Length - 1 && totalEnemies.Length == 0)
            {
                print("game Sesh");
            }
        }
    }


    private void SpwanNextWave()
    {
        currentWaveNumber++;
        canSpwan = true;
    }




    private void SpawnWave()
    {
        if (canSpwan && nextSpwanTime < Time.time)
        {
            GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];
            Transform randomPos = spwanPoints[Random.Range(0, spwanPoints.Length)];
            Instantiate(randomEnemy, randomPos.position, Quaternion.identity);
            currentWave.noOFEnemies--;

            nextSpwanTime = Time.time + currentWave.spwanInterval;

            if (currentWave.noOFEnemies <= 0) 
            {
                canSpwan = false;
                canAnimate = true;
            }
        }
    }










}
