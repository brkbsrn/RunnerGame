using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Transform StartTransform;
    public Transform StartTransform2;
    private List<Collider> movingPlatforms = new List<Collider>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle1"))
        {
            transform.position = StartTransform.position;
        }
        else if (other.CompareTag("Obstacle2"))
        {
            transform.position = StartTransform2.position;
        }
        else if (other.CompareTag("MovingPlatform"))
        {
            movingPlatforms.Add(other);
            transform.parent = other.transform;
        }
        else if (other.CompareTag("Finish"))
        {
            GameManager.Instance.GameFinish();
        }

    }

    internal void GameStart()
    {
        transform.position = StartTransform.position;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MovingPlatform"))
        {
            movingPlatforms.Remove(other);
            if (movingPlatforms.Count == 0)
            {
                transform.parent = null;
            }
        }
        
    }
}
