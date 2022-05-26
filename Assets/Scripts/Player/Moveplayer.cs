using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveplayer : MonoBehaviour
{
    private bool MoveByTouch;
    private Vector3 Direction;
    [SerializeField] private float runSpeed, velocity, swipeSpeed, roadSpeed;
    [SerializeField] private Transform road;

    Rigidbody snake_rb;
    void Start()
    {
      //  snake_rb = GetComponent<Rigidbody>();
        snake_rb.GetComponentInChildren<Rigidbody>();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            MoveByTouch = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            MoveByTouch = false;
        }

        if (MoveByTouch)
        {

            Direction.x = Mathf.Lerp(Direction.x, Input.GetAxis("Mouse X"), Time.deltaTime * runSpeed);

            Direction = Vector3.ClampMagnitude(Direction, 1f);

            road.position = new Vector3(0f, 0f, Mathf.SmoothStep(road.position.z, -100f, Time.deltaTime * roadSpeed));

        }
            if (snake_rb.velocity.magnitude > 0.5f)
            {
            snake_rb.rotation = Quaternion.Slerp(snake_rb.rotation, Quaternion.LookRotation(snake_rb.velocity), Time.deltaTime * velocity);
            }
            else
            {
            snake_rb.rotation = Quaternion.Slerp(snake_rb.rotation, Quaternion.identity, Time.deltaTime * velocity);
            }  
    }

    private void FixedUpdate()
    {
        if (MoveByTouch)
        {
            Vector3 displacement = new Vector3(Direction.x, 0f, 0f) * Time.fixedDeltaTime;
            snake_rb.velocity = new Vector3(Direction.x * Time.fixedDeltaTime * swipeSpeed, 0f, 0f) + displacement;
        }
        else
        {
            snake_rb.velocity = Vector3.zero;
        }
    }
}
