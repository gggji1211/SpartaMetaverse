using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1.5f; // ��ֹ��� �ִ� Y ��ġ
    public float lowPosY = -1.5f; // ��ֹ��� �ּ� Y ��ġ

    public float holeSizeMin = 2f; // ����(��� ����)�� �ּ� ũ�� (�������� ����)
    public float holeSizeMax = 3.5f; // ����(��� ����)�� �ִ� ũ�� (�������� ����)

    public Transform topObject; // ���� ��ֹ�
    public Transform bottomObject; // �Ʒ��� ��ֹ�

    public float widthPadding = 4.5f; // ��ֹ� �� ���� �Ÿ� ���� (���� ����)

    GameManager gamemanager;

    private void Start()
    {
        gamemanager = GameManager.Instance;
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        // ���� ũ�⸦ �������� ����
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2;

        // ��ֹ��� �߾� ���� Y ��ġ ����
        float centerY = Random.Range(lowPosY, highPosY);

        // ����, �Ʒ��� ��ֹ� ��ġ ����
        topObject.localPosition = new Vector3(0, centerY + halfHoleSize, 0);
        bottomObject.localPosition = new Vector3(0, centerY - halfHoleSize, 0);

        // ���ο� ��ֹ� ��ġ ���
        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0, 0);

        // ��ֹ��� ��ġ ����
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
