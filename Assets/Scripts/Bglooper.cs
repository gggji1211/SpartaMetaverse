using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bglooper : MonoBehaviour
{
    public int numBgCount = 5;
    public int obstacleCount = 0; // 장애물의 개수를 저장하는 변수
    public Vector3 obstacleLatPosition = Vector3.zero; // 마지막 장애물의 위치를 저장하는 변수

    // Start는 게임이 시작될 때 한 번 실행되는 함수
    void Start()
    {
        // 현재 씬에서 모든 Obstacle 객체를 찾아 배열에 저장
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();

        // 첫 번째 장애물의 위치를 obstacleLatPosition 변수에 저장
        obstacleLatPosition = obstacles[0].transform.position;

        // 장애물 개수를 obstacleCount 변수에 저장
        obstacleCount = obstacles.Length;

        // 모든 장애물의 위치를 랜덤하게 재배치
        for (int i = 0; i < obstacleCount; i++)
        {
            // 각 장애물을 SetRandomPlace를 통해 새로운 위치로 이동시킴
            obstacleLatPosition = obstacles[i].SetRandomPlace(obstacleLatPosition, obstacleCount);
        }
    }

    // 트리거 충돌이 발생했을 때 실행되는 함수
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


        // 충돌한 오브젝트에서 Obstacle 컴포넌트를 가져옴
        Obstacle obstacle = collision.GetComponent<Obstacle>();

        // 만약 obstacle이 존재하면 위치를 랜덤하게 재설정
        if (obstacle)
        {
            obstacleLatPosition = obstacle.SetRandomPlace(obstacleLatPosition, obstacleCount);
        }
    }
}
