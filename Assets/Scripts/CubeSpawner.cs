using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CubeSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject spawnablePrefab;
    [SerializeField]
    private LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        InputManager.instance.registerOnClickInput(onClick);
    }

    private void OnDestroy()
    {
        InputManager.instance.unregisterOnClickInput(onClick);
    }


    private void onClick(InputAction.CallbackContext callbackContext)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10000,  groundLayer) && spawnablePrefab != null)
        {
            GameObject.Instantiate(spawnablePrefab, hit.point + Vector3.up, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
