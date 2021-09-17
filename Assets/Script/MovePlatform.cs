using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour  //平台移动实现，用于部分物品的移动，后续修改
{
    public float speedX,speedY;
    public float rangeX, rangeY;
    private Vector3 object_postion;
    private float originX, originY;
    // Start is called before the first frame update
    void Start()
    {
        object_postion =this.transform.position;
        originX = object_postion.x;
        originY = object_postion.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speedY * Time.deltaTime;
        transform.position += Vector3.right * speedX * Time.deltaTime;
        if (transform.position.x > originX+ rangeX|| transform.position.x < originX - rangeX)
        {
            speedX = -speedX;
        }
        if (transform.position.y > originY + rangeY || transform.position.y < originY - rangeY)
        {
            speedY = -speedY;
        }
    }
}
