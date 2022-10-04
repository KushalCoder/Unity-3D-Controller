using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBindings : MonoBehaviour
{
    public float speed = 30f;
    float xVel;
    float zVel;
    public CharacterController cont;
    public float gravity = 13f;
    Vector3 velocity;

    public Transform grndCheck;
    public float grndDist = 0.4f;
    public LayerMask grndMask;
    bool isGrounded;
    public float jumpVel = 5f;

    void Update()
    {

        isGrounded = Physics.CheckSphere(grndCheck.position,grndDist,grndMask);

        if (isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        if (Input.GetButton("Jump") && isGrounded){
            velocity.y = jumpVel;
        }

        xVel = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        zVel = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        Vector3 move = transform.right * xVel + transform.forward * zVel;
        cont.Move(move * speed * Time.deltaTime);
        velocity.y -= gravity * Time.deltaTime;
        cont.Move(velocity * Time.deltaTime);
    }
}
