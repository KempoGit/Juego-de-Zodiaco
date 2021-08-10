using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float jumpForce = 5;

    private Rigidbody2D _rigidbody;
    private float _velocity;

    private void Awake()
    {
        _rigidbody = transform.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.velocity = new Vector2(_velocity * moveSpeed, _rigidbody.velocity.y);

    }

    public void Move(InputAction.CallbackContext context)
    {
        _velocity = context.ReadValue<Vector2>().x;
    }

}
