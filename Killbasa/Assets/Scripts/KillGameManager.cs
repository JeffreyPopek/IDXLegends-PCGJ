using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class KillGameManager : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData; //Do you want the variables in playerData visible in this gamemanager? -Jon
    [SerializeField] private ResourceManager _resourceManager;

    public int difficulty;
    public KillTarget targetPrefab;
    public int score = 0;
    public float spawnRangeX;
    public float spawnRangeY;
    private float spawnTimer = 0;
    public float spawnTime;
    public float minSpawnTime;
    public float maxSpawnTime;
    private float copChance = 0;

    public enum Direction { North, South, East, West }

    public GameObject[] spawnPositions;
    public GameObject[] validSpawnPositions;
    
    public enum EnemyType { Fatty, Lean, Rich }

    public EnemyType enemyType;

    public float fattyChance;
    public float leanChance;
    public float richChance;


    //New vars
    public float lbsGainedPerKill = 100;

    public float caughtBasePenalty = 1000;
    public float caughtPenaltyMult = 1.5f;
    
    private void Update()
    {
        spawnTimer += Time.deltaTime;

        

        if (spawnTimer > spawnTime)
        {
            float r = Random.Range(0, 100);

            if(r < fattyChance)
            {
                enemyType = EnemyType.Fatty;
            }
            else if (r < leanChance + fattyChance)
            {
                enemyType = EnemyType.Lean;
            }
            else
            {
                //remainder is for rich
                enemyType = EnemyType.Rich;
            }

            SpawnTarget();
            spawnTimer = 0.0f;
            spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }

    private void Start()
    {
        StartMinigame();
        TextManager.Instance.UpdateUI();
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
        newTarget.enemyType = this.enemyType;

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

        switch (enemyType)
        {
            case (EnemyType.Fatty):
                newTarget.lifespan = 2.7f;
                newTarget.movementSpeed = 0;
                newTarget.transform.position += new Vector3(newTarget.xDirection, newTarget.yDirection, 0) * Random.Range(0f, 2f);
                Debug.Log("Fatty target spawned");
                break;

            case (EnemyType.Lean):
                newTarget.lifespan = 2.1f;
                newTarget.movementSpeed = Random.Range(.8f,1.2f);
                Debug.Log("Lean target spawned");
                break;

            case (EnemyType.Rich):
                newTarget.lifespan = 1.1f;
                newTarget.movementSpeed = 0;
                newTarget.transform.position += new Vector3(newTarget.xDirection, newTarget.yDirection, 0) * Random.Range(0f, 2f);
                Debug.Log("Rich target spawned");
                break;

        }

        //Can we change this to work with "suspicion" over multiple days? -Jon
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

    private void OnMouseDown() //Reason for this is I felt that each click (including misses) represents a "kill attempt", so suspicion should rise as a result. -Jon
    {
        _playerData.Suspicion += 1;
    }

    public void TargetClickedGood(EnemyType eType)
    {
        switch(eType)
        {
            case (EnemyType.Fatty):
                _resourceManager._LBFattyMeat += lbsGainedPerKill;
                _resourceManager.UpdatePlayerData();
                //Debug.Log("LBFatty: " + _playerData.LBFatty);
                break;

            case (EnemyType.Lean):
                _resourceManager._LBLeanMeat += lbsGainedPerKill;
                _resourceManager.UpdatePlayerData();
                //Debug.Log("LBLean: " + _playerData.LBLean);
                break;

            case (EnemyType.Rich):
                _resourceManager._LBRichMeat += lbsGainedPerKill;
                _resourceManager.UpdatePlayerData();
                //Debug.Log("LBRich: " + _playerData.LBRich);
                break;
        }
    }

    public void TargetClickedBad() //I think this should immediately end the night and apply fines/penalties
    {
        _resourceManager._timesCaught++;
        _resourceManager._currentMoney -= _resourceManager._timesCaught * caughtBasePenalty;
        _resourceManager.UpdatePlayerData();
        //TODO have UI that stops game, make player click "End Night" button to go to next day
        TextManager.Instance.GoToNextDay();
    }
}
