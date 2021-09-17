using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager sharedInstance;
    public SpawnPoint playerSpawnPoint;
    public static CameraShake camShake;
    public CameraManager cameraManager;
    private GameObject player;

    private void Awake()
    {
        if (sharedInstance != null && sharedInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            sharedInstance = this;
        }
    }

    void Start()
    {
        SetupScene();
    }

    // Update is called once per frame
    public void SetupScene()
    {
        //µ»ª·‘Ÿ–¥
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        if (playerSpawnPoint != null)
        {
            player = playerSpawnPoint.SpawnObject();
            cameraManager.virtualCamera.Follow = player.transform;
        }
    }

    public GameObject GetPlayer()
    {
        return player;
    }
}
