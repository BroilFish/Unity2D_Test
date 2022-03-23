using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{

    // 如果另一个碰撞器 2D 进入了触发器，则调用 OnTriggerEnter2D (仅限 2D 物理)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("in OnTriggerEnter2D");
        //Debug.Log(collision);
        // 获取ruby的RubyControl组件，collision代表ruby的碰撞体
        RubyControl rubyControl = collision.GetComponent<RubyControl>();
        // 当前发生触发检测的游戏物体对象是否有RubyControl脚本
        if(rubyControl!=null)
        {
            Debug.Log("rubyControl is not null");
            // ruby是否满血
            if (rubyControl.Health < rubyControl.maxHealth)
            {
                Debug.Log("rubyControl is not null");
                // ruby是不满血
                // 碰撞回血
                rubyControl.ChangeHealth(1);
                // 碰撞后销毁(gameObject代表当前组件的对象)
                Destroy(this.gameObject);
            }

        }
    }



}
