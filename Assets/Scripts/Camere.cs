using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camere : MonoBehaviour
{
    public Transform target; // 따라갈 대상 (예: 플레이어의 Transform을 할당해야 함)
    private float offsetX;   // 카메라와 대상 간의 X축 거리 오프셋

    void Start()
    {
        if (target == null) return; // 대상이 설정되지 않았다면 더 이상 실행하지 않음

        // 카메라와 대상 간의 초기 X 위치 차이를 저장하여, 상대적 위치를 유지하도록 함
        offsetX = transform.position.x - target.position.x;
    }

    void Update()
    {
        if (target == null) return; // 대상이 없으면 실행하지 않음

        // 현재 카메라의 위치를 가져옴
        Vector3 pos = transform.position;

        // 대상의 X 위치를 기준으로 오프셋을 유지하면서 따라가도록 설정
        pos.x = target.position.x + offsetX;

        // 업데이트된 위치를 카메라에 적용
        transform.position = pos;
    }
}
