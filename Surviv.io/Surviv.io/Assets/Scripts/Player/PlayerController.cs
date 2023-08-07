using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Joystick joystick;
    public Joystick joystickRota;

    public float rotateHorizontal;
    public float rotateVertical;
    private Rigidbody2D rb;

    Vector2 move;

    public float moveSpeed = 35f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        move.x = joystick.Horizontal;
        move.y = joystick.Vertical;

        Vector3 moveVector = (Vector3.up * joystickRota.Vertical - Vector3.left * joystickRota.Horizontal);
        if (joystickRota.Horizontal != 0 || joystickRota.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
    }


}
