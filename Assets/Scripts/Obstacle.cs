using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1.5f; // 장애물의 최대 Y 위치
    public float lowPosY = -1.5f; // 장애물의 최소 Y 위치

    public float holeSizeMin = 2f; // 구멍(통과 공간)의 최소 크기 (이전보다 증가)
    public float holeSizeMax = 3.5f; // 구멍(통과 공간)의 최대 크기 (이전보다 증가)

    public Transform topObject; // 위쪽 장애물
    public Transform bottomObject; // 아래쪽 장애물

    public float widthPadding = 4.5f; // 장애물 간 가로 거리 간격 (조금 증가)

    GameManager gamemanager;

    private void Start()
    {
        gamemanager = GameManager.Instance;
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        // 구멍 크기를 랜덤으로 설정
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2;

        // 장애물의 중앙 기준 Y 위치 설정
        float centerY = Random.Range(lowPosY, highPosY);

        // 위쪽, 아래쪽 장애물 위치 조정
        topObject.localPosition = new Vector3(0, centerY + halfHoleSize, 0);
        bottomObject.localPosition = new Vector3(0, centerY - halfHoleSize, 0);

        // 새로운 장애물 위치 계산
        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0, 0);

        // 장애물의 위치 적용
        transform.position = placePosition;

        return placePosition;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            gamemanager.AddScore(1);
        }
    }
}
