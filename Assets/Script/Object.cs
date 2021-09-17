using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public string Message;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other) //信息交互实现
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log(Message);    //UI负责人请将该处处理为合适的界面信息
            }
        }
    }

    public static explicit operator AudioClip(Object v)
    {
        throw new NotImplementedException();
    }
}
