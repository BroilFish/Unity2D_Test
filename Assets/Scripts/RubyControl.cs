using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyControl : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    public int maxHealth = 5;   // �������ֵ
    private int currentHealth;  // Ruby��ǰ����ֵ
    public int speed = 3;       // Ruby�ٶ�ֵ 

    // ��װ����get��set ��ݼ�Ctrl+R Ctrl+E
    public int Health { get => currentHealth;}


    // Start is called before the first frame update
    void Start()
    {
        // ��ȡ�������
        rigidbody2d = GetComponent<Rigidbody2D>();
        // ��Ϸ��ʼ��Ѫ����Ѫ
        currentHealth = maxHealth;
        currentHealth = 4;
        //int a = GetRubyHealthValue();
        Debug.Log("Ruby��ǰ��Ѫ����: " + currentHealth);

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector2 position = transform.position;
        position.x = position.x + speed*horizontal*Time.deltaTime;
        position.y = position.y + speed * vertical*Time.deltaTime;

        //transform.position = position;
        // ͨ���������Ⱦ�����ƶ�
        rigidbody2d.MovePosition(position);

    }

    // Ѫ���ı亯��
    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log("Ѫ����ʼ�仯:" + currentHealth + "/" + maxHealth);

    }

    //// ��ȡ��ǰRubyѪ��
    //private int GetRubyHealthValue()
    //{
    //    return currentHealth;
    //}
    
}
