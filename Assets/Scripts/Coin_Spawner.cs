using System.Collections;
using UnityEngine;

public class Coin_Spawner : MonoBehaviour
{
    public GameObject coinPrefab;

    void Start()
    {
        StartCoroutine(CoinSpawner());
    }
    
    void Update()
    {
    }
    
    void CoinSpawn()
    {
        float rand = Random.Range(-3.3f, 3.2f);
        Instantiate(coinPrefab,new Vector3(rand,transform.position.y,transform.position.z),Quaternion.identity);
    }
    
    IEnumerator CoinSpawner()
    {
        while(true)
        {
            int time = Random.Range(5, 10);
            yield return new WaitForSeconds(time);
            CoinSpawn();
        }
    }
}
