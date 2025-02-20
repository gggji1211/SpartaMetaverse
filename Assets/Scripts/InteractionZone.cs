using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // 플레이어가 진입했을 때만 실행
        {
            Debug.Log("특정 영역에 들어왔습니다!");
            // 여기에 원하는 이벤트 추가 (예: 대화 시작, 미니게임 시작 등)
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("특정 영역에서 나갔습니다!");
        }
    }
}
