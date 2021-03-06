﻿using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public float SpawnSpeed = 0.9f;
    public GameObject[] ObjectToSpawn;

    private Bounds spawnRange;
    // Use this for initialization
    void Start()
    {
        if (ObjectToSpawn == null)
            Debug.LogError("ObjectToSpawn is empty!");

        var colider = GetComponentInChildren<BoxCollider2D>();
        spawnRange = colider.bounds;
        //if (Colors.Length <= 0)
        //    Debug.LogError("You have to set colorset!");

        InvokeRepeating("Spawn", 1f, SpawnSpeed);
    }

    // Update is called once per frame
    void Update()
    {

        //SetRandomSetting(ObjectToSpawn);
    }



    void Spawn()
    {
        var randomXposition = Random.Range(spawnRange.min.x, spawnRange.max.x);
        Vector3 newpos = new Vector3(randomXposition, transform.position.y);

        var rotation = (float)Random.Range(0, 360);

        var rand = Random.Range(0, ObjectToSpawn.Length);
        //SetRandomSetting(ObjectToSpawn);
        var go = (GameObject)Instantiate(ObjectToSpawn[rand], newpos, Quaternion.Euler(0, 0, rotation));

    }

}