using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] GameObject deathFX;


    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        Invoke("ReloadLevel", levelLoadDelay);
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("collided");
    }

    private void StartDeathSequence()
    {
        SendMessage("HasDied");
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
