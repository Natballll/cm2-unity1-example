using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Raycast : MonoBehaviour
{
    public float groundCheckDistance = 0.1f; // How far below to check for ground
    public LayerMask groundMask;             // Which layers count as ground
    public Transform groundCheckPoint;       // Where the raycast starts (e.g. feet)

    private Rigidbody rb;
    private bool isGrounded = false;
    private Transform currentPlatform = null;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // If no point assigned, use player position
        if (groundCheckPoint == null)
            groundCheckPoint = transform;
    }

    void FixedUpdate()
    {
        // Shoot a ray downward
        Ray ray = new Ray(groundCheckPoint.position, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, groundCheckDistance, groundMask))
        {
            isGrounded = true;

            // If the thing we hit is a platform, parent to it
            if (hit.collider.CompareTag("MovingPlatform"))
            {
                if (currentPlatform != hit.collider.transform)
                {
                    transform.SetParent(hit.collider.transform);
                    currentPlatform = hit.collider.transform;
                }
            }
            else
            {
                transform.SetParent(null);
                currentPlatform = null;
            }
        }
        else
        {
            isGrounded = false;
            transform.SetParent(null);
            currentPlatform = null;
        }
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }
}