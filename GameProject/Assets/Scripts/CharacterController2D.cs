using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float jumpForce = 100f;   
    [SerializeField] private LayerMask whatIsGround;
	[SerializeField] private Transform groundCheck;
	[SerializeField] private float delayGroundCheck = 0.25f;

    const float groundedRadius = .2f;
	private bool grounded;
	private Rigidbody2D rigidbody2d;
	private float timeBeforeGroundCheck = 0f;
    private bool doubleJumpAvaiable = true;

    private void Awake()
	{
		rigidbody2d = GetComponent<Rigidbody2D>();
	}

    private void Update()
	{
		if (!grounded)
		{
			timeBeforeGroundCheck -= Time.deltaTime;
		}
	}
	
	private void FixedUpdate()
	{
		if (timeBeforeGroundCheck > 0f)
		{
			return;
		}
		bool wasGrounded = grounded;
		grounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);

		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				grounded = true;
			}
		}
	}

    public void Move(float move, bool jump)
    {
        this.transform.Translate(Vector2.right * move);

        if (grounded)
		{
			doubleJumpAvaiable = true;
		}
        
        if (!grounded && jump && doubleJumpAvaiable)
		{
			rigidbody2d.velocity = Vector2.up * jumpForce;
			timeBeforeGroundCheck = delayGroundCheck;
            doubleJumpAvaiable = false;
		}

		if (grounded && jump)
		{
			rigidbody2d.velocity = Vector2.up * jumpForce;
			grounded = false;
			timeBeforeGroundCheck = delayGroundCheck;
		}
        
    }
}
