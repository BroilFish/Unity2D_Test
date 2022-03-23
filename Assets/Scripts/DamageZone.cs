using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    // 如果另一个碰撞器 2D 进入了触发器，则调用 OnTriggerEnter2D (仅限 2D 物理)
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("in OnTriggerEnter2D");
        //Debug.Log(collision);
        // 获取ruby的RubyControl组件，collision代表ruby的碰撞体
        RubyControl rubyControl = collision.GetComponent<RubyControl>();
        // 当前发生触发检测的游戏物体对象是否有RubyControl脚本
        if (rubyControl != null)
        {
            // 碰撞掉血
            rubyControl.ChangeHealth(-1);
            Debug.Log("Ruby当前的生命值："+rubyControl.Health);
            
        }
    }



}
