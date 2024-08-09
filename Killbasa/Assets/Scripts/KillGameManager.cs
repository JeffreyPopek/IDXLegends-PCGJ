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

    public GameObject[] spawnPositions;
    public GameObject[] validSpawnPositions;

    public enum EnemyType { Fatty, Lean, Rich }
    public enum Direction { North, South, East, West }

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
        int spawnPosition = Random.Range(0,spawnPositions.Length);
        GameObject spawnPoint = spawnPositions[spawnPosition];
        SpawnVariables spawnVars = spawnPoint.GetComponent<SpawnVariables>();

        List<Direction> spawnDirections = new List<Direction>();
        spawnDirections.Clear();

        if(spawnVars.roadNorth)
        {
            spawnDirections.Add(Direction.North);
        }
        if(spawnVars.roadSouth)
        {
            spawnDirections.Add(Direction.South);
        }
        if(spawnVars.roadEast)
        {
            spawnDirections.Add(Direction.East);
        }
        if(spawnVars.roadWest)
        {
            spawnDirections.Add(Direction.West);
        }

        Direction enemyDirection = spawnDirections[Random.Range(0,spawnDirections.Count)];

        

        KillTarget newTarget = Instantiate(targetPrefab);
        newTarget.transform.position = spawnPoint.transform.position;
        newTarget.manager = this;

        switch (enemyDirection)
        {
            case Direction.North:
                newTarget.yDirection = 1;
                //spawnPoint.transform.position += new Vector3(0, Random.Range(0,1), 0);
                break;

            case Direction.South:
                newTarget.yDirection = -1;
                break;

            case Direction.East:
                newTarget.xDirection = 1;
                break;

            case Direction.West:
                newTarget.xDirection= -1;
                break;

        }

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
