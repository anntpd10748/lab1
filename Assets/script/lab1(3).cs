using UnityEngine;
using System.Collections;

public class lab1bai3 : MonoBehaviour
{
    public GameObject prefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(TaoCube());
    }
    IEnumerator TaoCube()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(1);
            GameObject clone = Instantiate(prefab, new Vector3(1, 1, 1), Quaternion.identity);
            StartCoroutine(DiChuyen(clone));
        }
    }
    IEnumerator DiChuyen(GameObject clones)
    {
        float eclapsedTime = 0f;
        Vector3 des = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        while (eclapsedTime < 5f)
        {
            Vector3 pos = Vector3.Lerp(clones.transform.position, des, eclapsedTime / 5);
            clones.transform.position = pos;
            eclapsedTime += Time.deltaTime;
            yield return null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
