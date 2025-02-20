using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basecontroller : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    [SerializeField] private SpriteRenderer Renderer;
    [SerializeField] private Transform weaponPivot;

    public float Jump = 3f;  // 점프 높이 조정
    bool isFlap = false;

    protected Vector2 movementdirection = Vector2.zero;
    public Vector2 Movementdirection { get { return movementdirection; } }

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }

    private Vector2 knockback = Vector2.zero;
    private float knockbackDuration = 0.0f;

    protected virtual void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        HandleAction();
        Rotate(lookDirection);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFlap = true;
        }
    }

    protected virtual void FixedUpdate()
    {
        Movement(movementdirection);
        if (knockbackDuration > 0.0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }

        Vector2 velocity = _rigidbody2D.velocity;

        if (isFlap)
        {
            velocity.y = Jump;
            isFlap = false;
        }

        _rigidbody2D.velocity = velocity;
    }

    protected virtual void HandleAction()
    {

    }

    private void Movement(Vector2 direction)
    {
        direction = direction * 5;
        if (knockbackDuration > 0.0f)
        {
            direction *= 0.2f;
            direction += knockback;
        }

        _rigidbody2D.velocity = direction;
    }

    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        Renderer.flipX = isLeft;

        if (weaponPivot != null)
        {
            weaponPivot.rotation = Quaternion.Euler(0f, 0f, rotZ);
        }
    }

    public void ApplyKnockback(Transform other, float power, float duration)
    {
        knockbackDuration = duration;
        knockback = -(other.position - transform.position).normalized * power;
    }
}
