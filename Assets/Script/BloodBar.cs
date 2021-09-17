using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodBar : MonoBehaviour
{
    public PlayerHealth playerhealth;
    public Image meterimage;
    public Text hptext;
    public float maxhealthvalue;
    public Transform bloodbar;
    public GameObject DeadMenu;

    // Start is called before the first frame update
    void Start()
    {
        //playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        //maxhealthvalue =(float) playerhealth.health;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerhealth != null)
        {
            meterimage.fillAmount = (float)playerhealth.health / maxhealthvalue;
            hptext.text = "HP:" + (meterimage.fillAmount * maxhealthvalue);
        }
        else 
        {
            playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
            maxhealthvalue = (float)playerhealth.health;
        }

        if (playerhealth.health <= 0)
        {
            DeadMenu.SetActive(true);
        }
    }

    
}
