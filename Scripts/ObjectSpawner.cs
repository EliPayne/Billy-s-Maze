using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] public GameObject PickUp;
    [SerializeField] public GameObject PowerUpSpeed;
    [SerializeField] public GameObject PowerUpSize;
    [SerializeField] public GameObject PowerUpCamera;
    [SerializeField] int numberOfPickUp;
    [SerializeField] int numberOfPowerUp;
    [SerializeField] Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfPickUp; i++)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(0, 20), 0.5f, Random.Range(0, 20));
            Instantiate(PickUp, randomSpawnPosition, Quaternion.identity);
        }

        for (int i = 0; i < numberOfPowerUp; i++)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(0, 20), 0.5f, Random.Range(0, 20));
            Instantiate(PowerUpSpeed, randomSpawnPosition, Quaternion.identity);
        }

        for (int i = 0; i < numberOfPowerUp; i++)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(0, 20), 0.5f, Random.Range(0, 20));
            Instantiate(PowerUpSize, randomSpawnPosition, Quaternion.identity);
        }

        for (int i = 0; i < numberOfPowerUp; i++)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(0, 20), 0.5f, Random.Range(0, 20));
            Instantiate(PowerUpCamera, randomSpawnPosition, Quaternion.identity);
        }
    }
}
