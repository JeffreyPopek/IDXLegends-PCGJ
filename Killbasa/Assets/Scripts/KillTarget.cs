using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static KillGameManager;

public class KillTarget : MonoBehaviour
{
    public EnemyType enemyType;

    public KillGameManager manager;
    public float lifespan;
    public bool isCop = false;

    public int xDirection;
    public int yDirection;
    public float movementSpeed;

    private float lifeTimer = 0.0f;

    public float score;

    private void Start()
    {
        if (isCop)
            GetComponent<SpriteRenderer>().color = Color.red;
        else
        {
            switch (enemyType)
            {
                case (EnemyType.Fatty):
                    GetComponent<SpriteRenderer>().color = Color.cyan;
                    break;

                case (EnemyType.Lean):
                    GetComponent<SpriteRenderer>().color = Color.blue;
                    break;

                case (EnemyType.Rich):
                    GetComponent<SpriteRenderer>().color = Color.yellow;
                    break;

            }
        }      

    }

    private void Update()
    {
        lifeTimer += Time.deltaTime;

        

        transform.position += new Vector3(xDirection, yDirection, 0) * Time.deltaTime * movementSpeed;

        if (lifeTimer > lifespan)
            Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        if (isCop)
            manager.TargetClickedBad();
        else
            manager.TargetClickedGood(enemyType);

        Destroy(gameObject);
    }
}