using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiInput : MonoBehaviour
{
    public PlayerMove PlayerMove;
    public float LeftRightSpeed = 2f;

    public Vector2 direction = new Vector2(0f, 0.85f);

    private void Update()
    {
        if (Mathf.Abs(transform.position.x - 10f) < 1f)
        {
            direction.x = -direction.x;
        }
        else if (Mathf.Abs(transform.position.x - (-17.5f)) < 1f)
        {
            direction.x = -direction.x;
        }

        int dir = (int)Mathf.Sign(Random.Range(-1f, 1f));
        direction += Vector2.right * dir *  0.01f * LeftRightSpeed;
        if (Mathf.Abs(direction.x) > 0.5f)
            direction.x = Mathf.Sign(direction.x) * 0.5f;

        PlayerMove.ProcessInput(direction);
    }

   

    public void GameFinish()
    {
        enabled = false;
        PlayerMove.ProcessInput(Vector2.zero);
    }

    public void GameStart()
    {
        enabled = true;
    }
}
