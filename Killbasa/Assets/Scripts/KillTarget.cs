using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class KillTarget : MonoBehaviour
{
    public KillGameManager manager;
    public float lifespan;
    public bool isCop = false;

    public int xDirection;
    public int yDirection;
    public float movementSpeed;

    private float lifeTimer = 0.0f;

    private void Start()
    {
        if (isCop)
            GetComponent<SpriteRenderer>().color = Color.red;
        else
            GetComponent<SpriteRenderer>().color = Color.green;
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
            manager.TargetClickedGood();

        Destroy(gameObject);
    }
}