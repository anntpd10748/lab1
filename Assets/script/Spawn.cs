using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{
    public GameObject prefab;
    public GameObject spawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Spawner());  
    }
    IEnumerator Spawner()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(2);
            GameObject clone = Instantiate(prefab, spawn.transform.position, Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
