using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 a = transform.position;
        float h = Input.GetAxis("Horizontal");  //获取键盘的A、D键
        float v = Input.GetAxis("Vertical");     //获取键盘的W、S键
        a.x = a.x + 1f*h*Time.deltaTime;
        a.y = a.y + 1f*v*Time.deltaTime;
        Debug.Log(a.x);
        transform.position=a;
        // float horizontal = Input.GetAxis("Horizontal");
        // float vertical = Input.GetAxis("Vertical");

        // Vector2 position = transform.position;
        // position.x = position.x + 0.1f*horizontal*Time.deltaTime;
        // position.y = position.y + 0.1f*vertical*Time.deltaTime;

        // transform.position = position;

    }
}
