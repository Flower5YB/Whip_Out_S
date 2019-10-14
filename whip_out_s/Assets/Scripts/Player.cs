using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveController))]
public class Player : MonoBehaviour
{
    [System.Serializable]
    public class MouseInput
    {
        public Vector2 Damping; //카메라가 끌려오는 감도
        public Vector2 Sensitivity; //감도
    }
    [SerializeField]float speed;   //인스펙터에 변수 노출
    [SerializeField]MouseInput MouseControl;    //인스펙터에 변수 노출

    private MoveController m_moveController;
    public MoveController MoveController
    {
        get
        {
            if (m_moveController == null)
                m_moveController = GetComponent<MoveController>();
            return m_moveController;
        }
    }


    InputController playerInput;
    Vector2 mouseInput;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = GameManager.Instance.InputController;
        GameManager.Instance.LocalPlayer = this;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(playerInput.Vertical * speed, playerInput.Horizontal * speed);
        MoveController.Move(direction);

        mouseInput.x = Mathf.Lerp(mouseInput.x, playerInput.MouseInput.x, 1f / MouseControl.Damping.x);

        transform.Rotate(Vector3.up * mouseInput.x * MouseControl.Sensitivity.x);
    }
}
