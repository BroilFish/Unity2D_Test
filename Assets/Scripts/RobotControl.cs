using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotControl : MonoBehaviour
{
    private Rigidbody2D r2d;                // 刚体组件
    public float speed = 3.0f;              // 速度
    public bool vertical;                   // 轴向控制
    private int direction = 1;              // 方向控制
    public float changeTime = 3.0f;         // 方向改变间隔
    private float timer;                    // 计时器
    
    // Start is called before the first frame update：
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
        Vector2 position = r2d.position;
        
        // 计时器 修改方向
        if (timer<0)
        {
            direction = -direction;
            timer = changeTime;
        }

        // 控制 垂直/纵向 移动
        if (vertical)
        {
            position.y = position.y +Time.deltaTime * speed *direction;
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed *direction;
        }
        r2d.MovePosition(position);
    }
 
 
    
    
    
}
