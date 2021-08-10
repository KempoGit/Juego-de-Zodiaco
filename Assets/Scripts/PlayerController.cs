using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float jumpForce = 5;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;

    private bool _isGrounded;
    private bool _facingRight = true;

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

        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        _rigidbody.velocity = new Vector2(_velocity * moveSpeed, _rigidbody.velocity.y);


        if (_velocity  < 0f && _facingRight == true)
        {
            Flip();
        }
        else if (_velocity > 0f && _facingRight == false)
        {
            Flip();
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        _velocity = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext value)
    {
        if (value.started && _isGrounded == true)
        {
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        float localScaleX = this.transform.localScale.x;
        // Da vuelta el valor del scale X
        localScaleX = localScaleX * -1f;
        // Y lo asigna
        this.transform.localScale = new Vector3(localScaleX, this.transform.localScale.y, this.transform.localScale.z);
    }

}
