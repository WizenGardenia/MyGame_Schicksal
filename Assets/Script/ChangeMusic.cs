using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    public AudioSource audioSource_1;   //����MainCamera�ϵ���ƵԴ
    public AudioSource audioSource_2;   //���ڴ������ϵ���ƵԴ
    public AudioClip clip;
    private bool IsBossBattleBegin;
    private bool IsBossBattleEnd;
    // Start is called before the first frame update
    void Start()
    {
        IsBossBattleBegin = false;
        IsBossBattleEnd = false;
}

    // Update is called once per frame
    void Update()
    {
        IsBossBattleBegin = GetComponent<EnemyEsengut>().IsBattle();
        IsBossBattleEnd = GetComponent<EnemyEsengut>().IsBattleEnd();
        if (audioSource_1.isPlaying && IsBossBattleBegin == true)
        {
            audioSource_1.Pause();
            audioSource_2.Play();
        }else if (IsBossBattleEnd == true)
        {
            audioSource_2.Stop();
            audioSource_1.clip = clip;
            audioSource_1.Play();
            
            
            Destroy(gameObject);
        }


    }

    //void OnTriggerEnter2D(Collider2D other) //������������崥��ʱ���л�BGM
    //{
    //    if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
    //    {
    //        if (audioSource_1.isPlaying) //�ж������Ƿ��ڲ���
    //        {
    //            audioSource_1.Stop();
    //            audioSource_2.Play();
    //        }
    //        else
    //        {
    //            audioSource_2.Stop();
    //            audioSource_1.Play();
    //        }
    //    }
    //}
}
