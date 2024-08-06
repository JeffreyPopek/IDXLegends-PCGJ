using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGameManager : MonoBehaviour
{
    public int difficulty;
    public KillTarget targetPrefab;
    public int score = 0;
    public float spawnRangeX;
    public float spawnRangeY;
    private float spawnTimer = 0;
    public float spawnTime;
    private float copChance = 0;

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer > spawnTime)
        {
            SpawnTarget();
            spawnTimer = 0.0f;
        }
    }

    public void StartMinigame()
    {

    }

    public void SpawnTarget()
    {
        float spawnX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnY = Random.Range(-spawnRangeY, spawnRangeY);

        KillTarget newTarget = Instantiate(targetPrefab);
        newTarget.transform.position = new Vector3(spawnX, spawnY, 0);
        newTarget.manager = this;

        float r = Random.Range(0.0f, 10.0f);
        if (r < copChance)
        {
            newTarget.isCop = true;
            copChance = 0;
        }
        else
        {
            copChance++;
        }
    }

    public void ClearAllTargets()
    {

    }

    public void TargetClickedGood()
    {
        score++;
        Debug.Log("Score: " + score);
    }

    public void TargetClickedBad()
    {
        score--;
        Debug.Log("Score: " + score);

    }
}
