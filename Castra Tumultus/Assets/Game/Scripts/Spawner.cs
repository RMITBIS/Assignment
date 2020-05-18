using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;

    public float radius = 10f;
    public float waveDelay = 30.0f;
    public float spawnModifier = 5f;
    public float wave = 1;

    private float timeTillWave;

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            timeTillWave += Time.deltaTime;

            if (timeTillWave >= waveDelay)
            {
                GameObject[] locations = GameObject.FindGameObjectsWithTag("Spawner");

                for (var i = 0; i < spawnModifier * wave; i++)
                {
                    GameObject loc = locations[Random.Range(0, locations.Length)];
                    Vector3 sp = loc.transform.position;

                    var xRandom = Random.Range(-radius, radius);
                    var yRandom = Random.Range(-radius, radius);
                    Vector3 position = new Vector3(sp.x + xRandom, 0, sp.z + yRandom);
                    GameObject obj = Instantiate(enemy, position, Quaternion.identity);
                    obj.tag = "Enemy";
                    Destroy(obj, 60);
                }

                wave++;
                timeTillWave -= waveDelay;
            }
        }
    }
}