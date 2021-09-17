using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEndBoss : SpawnPoint
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Boss_Esengut") == null)
        {
            InvokeRepeating("SpawnObject", 0.0f, repeatInterval);
            Destroy(gameObject);
        }
    }

    new public GameObject SpawnObject()
    {
        if (prefabToSpawn != null)
        {
            return Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        }
        return null;
    }
}
