using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    [SerializeField] private Rigidbody2D _rb;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movement();
    }


    void Movement()
    {
        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.position += new Vector3(move, 0f, 0f);
        float clampedX = Mathf.Clamp(transform.position.x, -7.5f, 7.5f);
        
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}