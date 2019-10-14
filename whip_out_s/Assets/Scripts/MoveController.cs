using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour //이동 조작 클래스
{
    public void Move(Vector2 direction)
    {
        transform.position += transform.forward * direction.x * Time.deltaTime +
            transform.right * direction.y * Time.deltaTime; //키입력 키보드 매핑
    }
}
