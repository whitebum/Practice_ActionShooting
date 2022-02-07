using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    CharacterController2D characterController2D;

    private void Awake()
    {
        characterController2D = GetComponent<CharacterController2D>();
    }

    private void Update()
    {
        characterController2D.input.x = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump"))
        {
            characterController2D.Jump();
        }
    }
}
