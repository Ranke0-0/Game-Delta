using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 2.5f;

	// References
	private Rigidbody2D _rigidbody;

    // MOVEMENT VARIABLES
    // Inputs
    float horizontalInput;
	float verticalInput;

    // Directions
    private Vector2 _movement;

    //private bool _facingRight = true;
    private bool _isAttacking = false; //Eing?

    void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	void Start()
    {
        
    }

    void Update()
    {
		if (_isAttacking == false)
		{
            // Si no está atacando, se mueve dependiendo de los inputs del user
            // Movement

            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            _movement = new Vector2(horizontalInput, verticalInput).normalized; // Normalizar para evitar velocidad mayor en diagonal

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
			float horizontalVelocity = _movement.normalized.x * speed;
			_rigidbody.linearVelocity = new Vector2(horizontalVelocity, _rigidbody.linearVelocity.y);

			float verticalVelocity = _movement.normalized.y * speed;
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
