using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyControl : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    public int speed = 3;       // Ruby速度值 
    
    // Ruby生命值
    public int maxHealth = 5;   // 最大生命值
    private int currentHealth;  // Ruby当前生命值


    // Ruby的无敌时间
    public float timeInvincible = 2.0f;     // 无敌时间
    public bool isInvincible;              // 无敌状态
    public float invincibleTimer;          // 无敌计时器

    // 封装属性get和set 快捷键Ctrl+R Ctrl+E
    public int Health { get => currentHealth;}


    // Start is called before the first frame update
    void Start()
    {
        // 获取刚体组件
        rigidbody2d = GetComponent<Rigidbody2D>();
        
        // 游戏开始，属性初始化
        invincibleTimer = timeInvincible;       // 无敌计时器时间
        isInvincible = false;                   // 是否无敌状态
        currentHealth = maxHealth;              // 游戏开始，血量满血
        
        // currentHealth = 4;
        //int a = GetRubyHealthValue();
        Debug.Log("Ruby起始血量是: " + currentHealth);

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector2 position = transform.position;
        position.x = position.x + speed * horizontal*Time.deltaTime;
        position.y = position.y + speed * vertical*Time.deltaTime;

        //transform.position = position;
        // 通过刚体的渲染进行移动
        rigidbody2d.MovePosition(position);

        // 无敌累减（解决一直受伤害但需要从新碰撞才能掉血的问题）
        if(isInvincible)
        {
            invincibleTimer = invincibleTimer - Time.deltaTime;
            Debug.Log("无敌计时器："+invincibleTimer);
            if (invincibleTimer<=0)
            {
                isInvincible = false;
                Debug.Log("Ruby已在非无敌状态");
            }
        }

    }

    // 血量改变函数
    public void ChangeHealth(int amount)
    {
        // 受到伤害
        if (amount<0)
        {
            Debug.Log("当前无敌状态："+isInvincible);
            // 是否是无敌状态
            if (isInvincible)
            {
                // 无敌状态：血量不变化
                Debug.Log("无敌状态：血量不变化");
                return;
            }
            // 重新初始化无敌状态
            Debug.Log("重新打开无敌状态");
            isInvincible = true;  // 打开无敌状态
            invincibleTimer = timeInvincible;  
        }
        

        
        // 非无敌状态，攻击掉血
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log("受到攻击，血量:" + currentHealth + "/" + maxHealth);
        
     

    }

    //// 获取当前Ruby血量
    //private int GetRubyHealthValue()
    //{
    //    return currentHealth;
    //}
    
}
