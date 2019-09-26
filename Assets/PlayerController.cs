/*/
* Script by Devin Curry
* www.Devination.com
* www.youtube.com/user/curryboy001
* Please like and subscribe if you found my tutorials helpful :D
* Twitter: https://twitter.com/Devination3D
/*/
using UnityEngine;
using System.Collections;



public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    // movement
    public float speed = 10, jumpVelocity = 10;
    public LayerMask playerMask;
    public bool canMoveInAir = true;

    //Combat
    public int health = 3;
    public float invincibleTimeAfterHurt = 2;

    [HideInInspector]
    public Collider2D[] myColls;

    Transform myTrans, tagGround;
    Rigidbody2D myBody;
    bool isGrounded = false;
    float hInput = 0;
    AnimatorController myAnim;

    void Start()
    {
        instance = this;
        myColls = this.GetComponents<Collider2D>();
        myBody = this.GetComponent<Rigidbody2D>();
        myTrans = this.transform;
        tagGround = GameObject.Find(this.name + "/tag_ground").transform;
        myAnim = AnimatorController.instance;

        //  myBody = this.rigidbody2D;//Unity 4.6-
        myBody = this.GetComponent<Rigidbody2D>();//Unity 5+
        myTrans = this.transform;
        tagGround = GameObject.Find(this.name + "/tag_ground").transform;
        myAnim = AnimatorController.instance;
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.Linecast(myTrans.position, tagGround.position, playerMask);

#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT || UNITY_EDITOR
        Move(Input.GetAxisRaw("Horizontal"));
        if (Input.GetButtonDown("Jump"))
            Jump();
#else
  Move (hInput);
#endif
    }

    void Move(float horizonalInput)
    {
        if (!canMoveInAir && !isGrounded)
            return;

        Vector2 moveVel = myBody.velocity;
        moveVel.x = horizonalInput * speed;
        myBody.velocity = moveVel;
    }

    public void Jump()
    {
        if (isGrounded)
            myBody.velocity += jumpVelocity * Vector2.up;
    }

    public void StartMoving(float horizonalInput)
    {
        hInput = horizonalInput;

    }
}

  

