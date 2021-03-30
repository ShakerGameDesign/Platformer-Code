using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Movement : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 5;
    public Animator animator;
    private Rigidbody2D _rigidbody;
 
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
 
 
    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
 
        if (!Mathf.Approximately(0, movement))
        {
            transform.rotation =  movement < 0 ? Quaternion.Euler(0,180,0) : Quaternion.identity;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }
}