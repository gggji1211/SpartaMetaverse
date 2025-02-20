using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody2D;

    public float Jump = 3f;  // 점프 높이 조정
    public float speed = 3;  // 변수명 수정
    public bool isDead = false; // 죽었는지 여부 확인
    public bool godMod = false; // 무적모드 활성화 확인
    float deatCooldown = 0f;

    bool isFlap = false; // 점프를 했는지 안했는지

    GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.Instance;

        animator = GetComponentInChildren<Animator>(); //animator 가져옴
        _rigidbody2D = GetComponent<Rigidbody2D>(); // _rigidbody2D 를 가져옴


    }

    void Update()
    {


        if (isDead) //isDead가 true 면 
        {
            if (deatCooldown <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    gameManager.reStart();
                }
            }
            else
            {
                deatCooldown -= Time.deltaTime;
            }
        }
        else
        {

            //스페이스바나 마우스왼클릭시 isFlap true 로 설정하여 점프
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
            {
                isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead) return; // 죽어있으면 동작x

        Vector2 velocity = _rigidbody2D.velocity; //Rigidbody2D 의 속도를 가져옴
        velocity.x = speed; // x를 speed 값으로 설정하여 움직이게함

        if (isFlap)
        {
            velocity.y = Jump; // 위쪽으로 쩜프하게함
            isFlap = false; //isFlap = false; 초기화 하여 중복점프 방지
        }

        _rigidbody2D.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody2D.velocity.y * 10f), -90, 90);
        //위로이동할수도 캐릭터가 위를 보고 아래로 가면 아래를 봄
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMod) return; //갓모드라면 충돌무시 종료

        if (isDead) return; // 죽은상태라면 종료

        isDead = true; // 박으면 isDead 를 true로 만들며 사망상태 처리
        deatCooldown = 1f; // 사망후 일정 시간동안 정지


        animator.SetInteger("isDie", 1); // 애니메이션 
        gameManager.GameOver(); //
    }
}
