using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform playerTrasnform;
    [SerializeField]
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        if (playerTrasnform == null)
        {
            playerTrasnform = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }


    void LateUpdate()
    {
        if (playerTrasnform != null)
        {
            transform.position = playerTrasnform.position + offset;
        }
    }
}
