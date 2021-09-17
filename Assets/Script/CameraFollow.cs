using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//该脚本已弃用
public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float smoothing;//平滑因子

    public Vector2 minPosition;
    public Vector2 maxPosition;


    // Start is called before the first frame update
    void Start()
    {
        CameraManager.camShake = GameObject.FindGameObjectWithTag("CameraShake").GetComponent<CameraShake>();//查找对象并获取脚本组件，用脚本调用函数
        //现在可以在程序的任意位置按GameController.camShake参量调用CameraShake对象了
    }

    

    void LateUpdate()
    {
        if (target != null)
        {
            if (transform.position != target.position)
            {
                Vector3 targetPos = target.position;
                targetPos.x = Mathf.Clamp(targetPos.x, minPosition.x, maxPosition.x);
                targetPos.y = Mathf.Clamp(targetPos.y, minPosition.y, maxPosition.y);//限制摄像机的移动范围
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);//线性差值函数

            }
        }
    }
    //为了让场景变化以后能够设置镜头位置的公有方法
    public void SetCamPosLimit(Vector2 minPos, Vector2 maxPos)
    {
        minPosition = minPos;
        maxPosition = maxPos;
    }
}
