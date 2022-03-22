using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyControl : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    public int maxHealth = 5;   // 最大生命值
    private int currentHealth;  // Ruby当前生命值
    public int speed = 3;       // Ruby速度值 

    // 封装属性get和set 快捷键Ctrl+R Ctrl+E
    public int Health { get => currentHealth;}


    // Start is called before the first frame update
    void Start()
    {
        // 获取刚体组件
        rigidbody2d = GetComponent<Rigidbody2D>();
        // 游戏开始，血量满血
        currentHealth = maxHealth;
        currentHealth = 4;
        //int a = GetRubyHealthValue();
        Debug.Log("Ruby当前的血量是: " + currentHealth);

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
        // 通过刚体的渲染进行移动
        rigidbody2d.MovePosition(position);

    }

    // 血量改变函数
    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log("血量开始变化:" + currentHealth + "/" + maxHealth);

    }

    //// 获取当前Ruby血量
    //private int GetRubyHealthValue()
    //{
    //    return currentHealth;
    //}
    
}
