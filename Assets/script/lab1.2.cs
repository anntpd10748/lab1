using System.Collections;
using UnityEngine;

public class lab1 : MonoBehaviour
{
    public MeshRenderer cube;
    Color colora;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cube = GetComponent<MeshRenderer>();
        colora = cube.material.color;
    }
    IEnumerator alpha()
    {
        float alpha = colora.a;
        float time = 0f;
        for (int i = 0; i < 5; i++)
        {
            while (time < 5f)
            {
                time += Time.deltaTime;
                colora.a = Mathf.Lerp(alpha, 0, time / 5);
                cube.material.color = colora;
                yield return null;
            }
        }         
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(alpha());
        }
    }
}
