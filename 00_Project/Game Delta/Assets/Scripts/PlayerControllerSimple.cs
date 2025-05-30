using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerSimple : MonoBehaviour
{
	public float speed = 2.5f;

	// References
	private Rigidbody2D _rigidbody;

	// Movement
	private Vector2 _movementHorizontal;
    private Vector2 _movementVertical;
    private bool _facingRight = true;
	private bool _isAttacking = false;

    void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	void Start()
    {
        
    }

    void Update()
    {
		//Si no está atacando, se mueve dependiendo de los inputs del user
		if (_isAttacking == false) 
		{
			// Movement
			float horizontalInput = Input.GetAxisRaw("Horizontal");
            _movementHorizontal = new Vector2(horizontalInput, 0f);

            float verticalInput = Input.GetAxisRaw("Vertical");
            _movementVertical = new Vector2(0f, verticalInput);

            // Flip character (Se usará, pero hay que extenderlo cara a Up, Down, Left, Right)
            /*	if (horizontalInput < 0f && _facingRight == true) 
			*	{
			*		Flip();
			*	}	
			*	else if (horizontalInput > 0f && _facingRight == false) 
			*	{
			*		Flip();
			*	}
			*/
        }
	}

	void FixedUpdate()
	{
		if (_isAttacking == false) 
		{
			float horizontalVelocity = _movementHorizontal.normalized.x * speed;
			_rigidbody.linearVelocity = new Vector2(horizontalVelocity, _rigidbody.linearVelocity.y);
		}

        if (_isAttacking == false)
        {
            float verticalVelocity = _movementVertical.normalized.y * speed;
            _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, verticalVelocity);
        }
    }

	/*private void Flip()
	*{
	*	_facingRight = !_facingRight;
	*	float localScaleX = transform.localScale.x;
	*	localScaleX = localScaleX * -1f;
	*	transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
	*}
	*/
}
