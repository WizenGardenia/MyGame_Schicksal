using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager sharedInstance = null;
    public static CameraShake camShake;
    [HideInInspector]
    public CinemachineVirtualCamera virtualCamera;
    //用于存储静态变量   

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
        camShake = GameObject.FindGameObjectWithTag("CameraShake").GetComponent<CameraShake>();
        GameObject vCamGameObject = GameObject.FindWithTag("VirtualCamera");
        virtualCamera = vCamGameObject.GetComponent<CinemachineVirtualCamera>();
    }

    
    

}
