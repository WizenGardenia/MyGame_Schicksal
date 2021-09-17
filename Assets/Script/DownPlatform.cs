using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownPlatform : MonoBehaviour
{
    private Collider2D platf;
    // Start is called before the first frame update
    void Start()
    {
        platf = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetKey(KeyCode.S))
            {
                platf.isTrigger = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Invoke("Evoke",2);
        
    }
    void Evoke()
    {
        platf.isTrigger = false;
    }
}
