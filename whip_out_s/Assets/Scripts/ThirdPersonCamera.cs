using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] Vector3 cameraOffset;  //인스펙터 노출
    [SerializeField] float damping;
    Transform cameraLookTarget;
    Player localPlayer;

    void Awake()
    {
        GameManager.Instance.OnLocalPlayerJoined += HandleOnLocalPlayerJoined;
    }

    void HandleOnLocalPlayerJoined(Player player)
    {
        localPlayer = player;
        cameraLookTarget = localPlayer.transform.Find("cameraLookTarget");

        if (cameraLookTarget == null)
            cameraLookTarget = localPlayer.transform;
    }

   
    void Update()
    {
        Vector3 targetPosition = cameraLookTarget.position + localPlayer.transform.forward * cameraOffset.z +
            localPlayer.transform.up * cameraOffset.y +
            localPlayer.transform.right * cameraOffset.x;   //카메라의 위치를 캐릭터의 어깨너머로 보게함

        Quaternion targetRotation = Quaternion.LookRotation(cameraLookTarget.position - targetPosition, Vector3.up);

        transform.position = Vector3.Lerp(transform.position, targetPosition, damping * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, damping * Time.deltaTime);
    }
}
