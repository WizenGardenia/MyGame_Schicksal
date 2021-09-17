using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�ýű�������
public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float smoothing;//ƽ������

    public Vector2 minPosition;
    public Vector2 maxPosition;


    // Start is called before the first frame update
    void Start()
    {
        CameraManager.camShake = GameObject.FindGameObjectWithTag("CameraShake").GetComponent<CameraShake>();//���Ҷ��󲢻�ȡ�ű�������ýű����ú���
        //���ڿ����ڳ��������λ�ð�GameController.camShake��������CameraShake������
    }

    

    void LateUpdate()
    {
        if (target != null)
        {
            if (transform.position != target.position)
            {
                Vector3 targetPos = target.position;
                targetPos.x = Mathf.Clamp(targetPos.x, minPosition.x, maxPosition.x);
                targetPos.y = Mathf.Clamp(targetPos.y, minPosition.y, maxPosition.y);//������������ƶ���Χ
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);//���Բ�ֵ����

            }
        }
    }
    //Ϊ���ó����仯�Ժ��ܹ����þ�ͷλ�õĹ��з���
    public void SetCamPosLimit(Vector2 minPos, Vector2 maxPos)
    {
        minPosition = minPos;
        maxPosition = maxPos;
    }
}
