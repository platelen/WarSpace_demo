using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDefeat : MonoBehaviour
{
    private Transform playerBase;

    private void Start()
    {
        playerBase = GetComponent<Transform>();
    }

    private void Update()
    {
        if (playerBase.childCount == 0)
        {
            GameOver.IsPlayerDead = true;
        }
    }
}
