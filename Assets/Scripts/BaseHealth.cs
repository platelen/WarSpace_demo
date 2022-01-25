using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    public float healt;

    private void Update()
    {
        if (healt <= 0)
        {
            Destroy(gameObject);
        }
    }
}
