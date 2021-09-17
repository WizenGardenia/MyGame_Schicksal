using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class DialogueOnTriggerEnter : MonoBehaviour
{
    private DialogueSystemTrigger diaSysTrigger;
    
    private bool haveBeenTrigger = false;
    
    void Start()
    {
        diaSysTrigger = GetComponent<DialogueSystemTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            if (diaSysTrigger != null && haveBeenTrigger == false)
            {
                diaSysTrigger.OnUse();
                haveBeenTrigger = true;
            }
            
        }
    }

     
}
