using Cinemachine;
using UnityEngine;
using System.Collections;

public class switchcamera : MonoBehaviour
{
    public CinemachineVirtualCamera cam1;
    public CinemachineVirtualCamera cam2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam1.Priority = 2;
        cam2.Priority = 1;
        StartCoroutine(switchcam());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator switchcam()
    {
        yield return new WaitForSeconds(3);
        cam1.Priority = 1;
        cam2.Priority = 2;
    }

        
}
