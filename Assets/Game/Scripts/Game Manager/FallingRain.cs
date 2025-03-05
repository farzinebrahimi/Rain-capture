using System;
using UnityEngine;

public class FallingRain : MonoBehaviour
{
    public int damage = 5;

    private void Update()
    {
        if (transform.position.y < -5f)
        {
            GameManager.Instance.DamagePlayer(damage);
            Destroy(gameObject);
        }
    }
}
