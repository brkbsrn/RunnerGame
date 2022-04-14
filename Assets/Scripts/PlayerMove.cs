using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float MoveSpeed;
    private Animator anim;
    private bool game;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    
    public void ProcessInput(Vector2 direction)
    {
        float inputMagnitude = 0;
        if (direction != Vector2.zero)
        {
            Move(direction);
            inputMagnitude = direction.magnitude;
        }
        else
        {
            inputMagnitude = 0; 
        }
        anim.SetFloat("Input Magnitude", inputMagnitude);
    }

    private void Move(Vector2 moveDirection) 
    {
        Vector3 dir = Vector3.forward * moveDirection.y + Vector3.right * moveDirection.x;
        transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
        transform.position += dir * MoveSpeed * Time.deltaTime;
        
    }

}
