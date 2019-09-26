using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;

    private Animator myAnimator;

    [SerializeField]
    private float movementSpeed;

    private bool facingRight;
    

    

  

    

   




    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

       
       


        HandleMovement(horizontal);

        Flip(horizontal);
    }

    private void HandleMovement(float horizontal)
    {
        {
            myRigidbody2D.velocity = new Vector2(horizontal * movementSpeed, myRigidbody2D.velocity.y);

           


                myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
        }

     
        
    }

    private void HandleInput()
    {
      
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }

    }
   

    
    }

