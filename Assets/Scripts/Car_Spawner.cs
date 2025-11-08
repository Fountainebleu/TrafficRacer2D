using System.Collections;
using DefaultNamespace;
using UnityEngine;

public class Car_Spawner : MonoBehaviour
{
    public GameObject[] cars;

    void Start()
    {
        StartCoroutine(SpawnCars());
    }
    
    void Update()
    {

    }
    
    void Cars()
    {
        int rand = Random.Range(0,cars.Length);
        float randXPos = Random.Range(-3.3f, 3.2f);
        Instantiate(cars[rand], new Vector3(randXPos,transform.position.y,transform.position.z), Quaternion.Euler(0, 0, 90));
    }

    IEnumerator SpawnCars()
    {
        while(true)
        {
            yield return new WaitForSeconds(GameSettings.carSpawnInterval);
            Cars();
        }
    }
}
