using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
public class MovingPlatform : MonoBehaviour
{
    public Transform ptA;
    public Transform ptB;
    public float speed = 2f;
    public float coyoteTime = 0.1f;

    private Transform player;         // Reference to player transform
    private float unparentTimer = 0f;

    private Rigidbody rb;
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.interpolation = RigidbodyInterpolation.Interpolate;

        target = ptB.position;
    }

    void FixedUpdate()
    {
        Vector3 newposition = Vector3.MoveTowards(transform.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newposition);

        // if (Vector3.Distance(transform.position, target) < 0.05f)
        // {
        //     target = (target == ptA.position) ? ptB.position : ptA.position;
        // }

        // Check if the platform has reached the current target
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            // Switch the target to the other point
            if (target == ptB.position)
            {
                target = ptA.position;
            }
            else
            {
                target = ptB.position;
            }
        }
    }

    // // Parent player under platform
    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         collision.transform.SetParent(transform);
    //     }
    // }

    // private void OnCollisionStay(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         collision.transform.SetParent(transform);
    //     }
    // }

    // // // Unparent player from platform
    // private void OnCollisionExit(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         collision.transform.SetParent(null);
    //     }
    // }

}
