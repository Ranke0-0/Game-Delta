using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEightDirections : MonoBehaviour
{
    public float movSpeed = 3.3f;
    float speedX, speedY;

    // References
    private Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movSpeed;
        _rigidbody.linearVelocity = new Vector2(speedX, speedY);
    }
}
