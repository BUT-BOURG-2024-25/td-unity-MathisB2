using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAllCubesOnTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject[] cubes = GameObject.FindGameObjectsWithTag("Collectable");
            foreach (GameObject cube in cubes)
            {
                Destroy(cube);
            }
        }
    }
}
