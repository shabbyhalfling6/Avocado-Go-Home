using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public Transform spawner;
    public GameObject[] enemy = new GameObject[2];

    public float spawnSpeed = 0.2f;
    private float timer = 0.0f;

    public float spawnVelocity = 20.0f;

    public float spawnerDelay = 30.0f;


    // Use this for initialization
    void Start ()
    {
        timer = spawnerDelay;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Spawn();
            timer = spawnSpeed;
        }
    }

    void Spawn()
    {
        GameObject spawnedEnemy;

        spawnedEnemy = (GameObject)Instantiate(enemy[Random.Range(0,enemy.Length)], spawner.position, transform.rotation);
        spawnedEnemy.GetComponent<Rigidbody2D>().velocity = spawnVelocity * transform.localScale.x * -spawnedEnemy.transform.up;
    }
}
