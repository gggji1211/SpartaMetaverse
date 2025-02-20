using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bglooper : MonoBehaviour
{
    public int numBgCount = 5;
    public int obstacleCount = 0; // ��ֹ��� ������ �����ϴ� ����
    public Vector3 obstacleLatPosition = Vector3.zero; // ������ ��ֹ��� ��ġ�� �����ϴ� ����

    // Start�� ������ ���۵� �� �� �� ����Ǵ� �Լ�
    void Start()
    {
        // ���� ������ ��� Obstacle ��ü�� ã�� �迭�� ����
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();

        // ù ��° ��ֹ��� ��ġ�� obstacleLatPosition ������ ����
        obstacleLatPosition = obstacles[0].transform.position;

        // ��ֹ� ������ obstacleCount ������ ����
        obstacleCount = obstacles.Length;

        // ��� ��ֹ��� ��ġ�� �����ϰ� ���ġ
        for (int i = 0; i < obstacleCount; i++)
        {
            // �� ��ֹ��� SetRandomPlace�� ���� ���ο� ��ġ�� �̵���Ŵ
            obstacleLatPosition = obstacles[i].SetRandomPlace(obstacleLatPosition, obstacleCount);
        }
    }

    // Ʈ���� �浹�� �߻����� �� ����Ǵ� �Լ�
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("backGround"))
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x; //
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }


        // �浹�� ������Ʈ���� Obstacle ������Ʈ�� ������
        Obstacle obstacle = collision.GetComponent<Obstacle>();

        // ���� obstacle�� �����ϸ� ��ġ�� �����ϰ� �缳��
        if (obstacle)
        {
            obstacleLatPosition = obstacle.SetRandomPlace(obstacleLatPosition, obstacleCount);
        }
    }
}
