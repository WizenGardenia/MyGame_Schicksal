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

    void OnTriggerStay2D(Collider2D other) //��Ϣ����ʵ��
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log(Message);    //UI�������뽫�ô�����Ϊ���ʵĽ�����Ϣ
            }
        }
    }

    public static explicit operator AudioClip(Object v)
    {
        throw new NotImplementedException();
    }
}
