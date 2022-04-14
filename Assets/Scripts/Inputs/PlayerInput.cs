using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public FixedJoystick FixedJoystick;
    public PlayerMove PlayerMove;

    private void Update() 
    {      
        PlayerMove.ProcessInput(FixedJoystick.Direction);
    }

    public void GameFinish()
    {
        enabled = false;
        FixedJoystick.gameObject.SetActive(false);
        PlayerMove.ProcessInput(Vector2.zero);
        FixedJoystick.OnPointerUp(null);
    }

    public void GameStart()
    {
        enabled = true;
        FixedJoystick.gameObject.SetActive(true);
    }
}
