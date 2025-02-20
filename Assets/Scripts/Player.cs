using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody2D;

    public float Jump = 3f;  // ���� ���� ����
    public float speed = 3;  // ������ ����
    public bool isDead = false; // �׾����� ���� Ȯ��
    public bool godMod = false; // ������� Ȱ��ȭ Ȯ��
    float deatCooldown = 0f;

    bool isFlap = false; // ������ �ߴ��� ���ߴ���

    GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.Instance;

        animator = GetComponentInChildren<Animator>(); //animator ������
        _rigidbody2D = GetComponent<Rigidbody2D>(); // _rigidbody2D �� ������


    }

    void Update()
    {


        if (isDead) //isDead�� true �� 
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

            //�����̽��ٳ� ���콺��Ŭ���� isFlap true �� �����Ͽ� ����
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
            {
                isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead) return; // �׾������� ����x

        Vector2 velocity = _rigidbody2D.velocity; //Rigidbody2D �� �ӵ��� ������
        velocity.x = speed; // x�� speed ������ �����Ͽ� �����̰���

        if (isFlap)
        {
            velocity.y = Jump; // �������� �����ϰ���
            isFlap = false; //isFlap = false; �ʱ�ȭ �Ͽ� �ߺ����� ����
        }

        _rigidbody2D.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody2D.velocity.y * 10f), -90, 90);
        //�����̵��Ҽ��� ĳ���Ͱ� ���� ���� �Ʒ��� ���� �Ʒ��� ��
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMod) return; //������� �浹���� ����

        if (isDead) return; // �������¶�� ����

        isDead = true; // ������ isDead �� true�� ����� ������� ó��
        deatCooldown = 1f; // ����� ���� �ð����� ����


        animator.SetInteger("isDie", 1); // �ִϸ��̼� 
        gameManager.GameOver(); //
    }
}
