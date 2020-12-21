using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int scorePerHit = 12;
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int hits = 10;

    ScoreBoard scoreboard;
    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        scoreboard = FindObjectOfType<ScoreBoard>();
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider triggerBoxCollider = gameObject.AddComponent<BoxCollider>();
        triggerBoxCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        GameObject explosionFx = Instantiate(deathFX, transform.position, Quaternion.identity);
        explosionFx.transform.parent = parent;
        KillEnemy();
    }

    private void KillEnemy()
    {
        scoreboard.ScoreHit(scorePerHit);
        hits--;
        if (hits <= 1)
        {
            Destroy(gameObject);
        }
    }
}
