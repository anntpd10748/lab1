using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject prefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(TaoCube());
    } 
    IEnumerator TaoCube()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(2);
            GameObject clone = Instantiate(prefab, new Vector3(Random.Range(1f, 50f), Random.Range(1f, 50f), Random.Range(1f, 50f)), Quaternion.identity);
            StartCoroutine(DiChuyen(clone));
        }
    }
    IEnumerator DiChuyen(GameObject clones)
    {
        float eclapsedTime = 0f;
        while(eclapsedTime < 5f)
        {
            clones.transform.position = Vector3.Lerp(clones.transform.position, Vector3.zero, eclapsedTime/5);
            eclapsedTime += Time.deltaTime;
            yield return null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
