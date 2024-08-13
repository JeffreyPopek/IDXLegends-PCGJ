using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyParticle : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private float fadeSpeed = 1.0f;

    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float dt = Time.deltaTime;

        transform.position += new Vector3(0, moveSpeed * dt, 0);
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - fadeSpeed * dt);

        if (sr.color.a <= 0)
        {
            Destroy(gameObject);
        }
    }
}
