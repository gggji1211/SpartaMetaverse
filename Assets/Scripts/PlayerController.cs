using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Basecontroller
{
    private Camera camera;

    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertial = Input.GetAxisRaw("Vertical");
        movementdirection = new Vector2(horizontal, vertial).normalized;

        Vector2 mouePosition = Input.mousePosition;
        Vector2 worldPos = camera.ScreenToWorldPoint(mouePosition);
        lookDirection = (worldPos - (Vector2)transform.position);

        if (lookDirection.magnitude < .9f) 
        {
            lookDirection = Vector2.zero;
        }
        else 
        {
            lookDirection = lookDirection.normalized;
        }
    } 
    

    
}
