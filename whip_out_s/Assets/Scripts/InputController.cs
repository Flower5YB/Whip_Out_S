using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public float Vertical;
    public float Horizontal;
    public Vector2 MouseInput;

    void Update()
    {
        Vertical = Input.GetAxis("Vertical");   //키보드 a,d 화살표 매핑
        Horizontal = Input.GetAxis("Horizontal");   //키보드 w,s 화살표 매핑
        MouseInput = new Vector2(Input.GetAxisRaw("Mouse X"),Input.GetAxisRaw("Mouse Y"));  
    }
}
