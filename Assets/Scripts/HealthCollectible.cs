using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{

    // �����һ����ײ�� 2D �����˴������������ OnTriggerEnter2D (���� 2D ����)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("in OnTriggerEnter2D");
        //Debug.Log(collision);
        // ��ȡruby��RubyControl�����collision����ruby����ײ��
        RubyControl rubyControl = collision.GetComponent<RubyControl>();
        // ��ǰ��������������Ϸ��������Ƿ���RubyControl�ű�
        if(rubyControl!=null)
        {
            Debug.Log("rubyControl is not null");
            // ruby�Ƿ���Ѫ
            if (rubyControl.Health < rubyControl.maxHealth)
            {
                Debug.Log("rubyControl is not null");
                // ruby�ǲ���Ѫ
                // ��ײ��Ѫ
                rubyControl.ChangeHealth(1);
                // ��ײ������(gameObject����ǰ����Ķ���)
                Destroy(this.gameObject);
            }

        }
    }



}
