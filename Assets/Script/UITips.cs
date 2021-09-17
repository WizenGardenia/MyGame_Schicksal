using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITips : MonoBehaviour
{
    // Start is called before the first frame update
    public static Vector3 vec3, pos;
    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// ������꽫�ᴥ���¼�
    /// </summary>
    public void PointerDown()
    {
        vec3 = Input.mousePosition;//��ȡ��ǰ����λ��
        pos = transform.GetComponent<RectTransform>().position;//��ȡ�Լ����ڵ�λ��
    }

    /// <summary>
    /// �����קʱ��ᱻ�������¼�
    /// </summary>
    public void Drag()
    {
        Vector3 off = Input.mousePosition - vec3;
        //�˴�Input.mousePositionָ�����ק��������λ��
        //��ȥ�ղ��ڰ���ʱ��λ�ã��պþ��������ק��ƫ����
        vec3 = Input.mousePosition;//ˢ���������ק��������λ�ã������´���ק�ļ���
        pos = pos + off;//ԭ��image���ڵ�λ����Ȼ��Ҫ��ƫ��
        transform.GetComponent<RectTransform>().position = pos;//ֱ�ӽ��Լ�ˢ�µ�������
    }

    /// <summary>
    /// �˺����ӿڽ�������������Ի��򡱰�ť��onClick�¼�
    /// </summary>
    public void onShow()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// �˺����ӿڽ��������ȷ�ϡ���ť��onClick�¼�
    /// </summary>
    public void onOK()
    {
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
