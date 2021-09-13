using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveController : MonoBehaviour
{
    [Header("Movement")] 
    public float moveAccel;
    public float maxSpeed;

    private Rigidbody2D rig;

    [Header("Jump")] 
    public float jumpAccel;

    public bool isJumping;
    public bool isOnGround;

    [Header("Ground Raycast")] 
    public float groundRaycastDistance;
    public LayerMask groundLayerMask;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // read input
        if (Input.GetMouseButtonDown(0))
        {
            if (isOnGround)
            {
                isJumping = true;
            }
        }
    }

    private void FixedUpdate()
    {
        // raycast ground
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down,
            groundRaycastDistance, groundLayerMask);
        if (hit)
        {
            if (!isOnGround && rig.velocity.y <= 0)
            {
                isOnGround = true;
            }
        }
        else
        {
            isOnGround = false;
        }
        
        // kalkulasi velocity vector
        Vector2 vectorVelocity = rig.velocity;

        if (isJumping)
        {
            vectorVelocity.y += jumpAccel;
            isJumping = false;
        }
        
        //vectorVelocity.x = Mathf.Clamp(vectorVelocity.x + moveAccel * Time.deltaTime, 0.0f, maxSpeed);

        rig.velocity = vectorVelocity;
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position, transform.position + (Vector3.down * groundRaycastDistance), 
            Color.white);
    }
}
