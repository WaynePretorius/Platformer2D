using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float jumpVelocity = 5f;

    private Rigidbody2D myBody;
    private Animator anim;
    private Collider2D colider;

    private float gravityScale;

    private void Awake()
    {
        AwakeFunctions();
    }

    private void AwakeFunctions()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        colider = GetComponent<Collider2D>();
    }

    private void Start()
    {
        StartFunctions();
    }

    private void StartFunctions()
    {
        gravityScale = myBody.gravityScale;
    }

    void Update()
    {
        Movement();
        FlipCharacter();
        Jump();
        Climb();
    }

    private void Movement()
    {

        float playerThrow = Input.GetAxis(Tags.MOVE_HORIZONTAL);

        Vector2 newPos = new Vector2(playerThrow * walkSpeed, myBody.velocity.y);

        myBody.velocity = newPos;

        bool isCharacterMoving = Mathf.Abs(myBody.velocity.x) > Mathf.Epsilon;
        anim.SetBool(Tags.ANIM_IS_WALKING, isCharacterMoving);

    }

    private void Jump()
    {

        bool isPlayerGrounded = colider.IsTouchingLayers(LayerMask.GetMask(Tags.LAYER_GROUND));

        if (Input.GetButtonDown(Tags.MOVE_JUMP) && isPlayerGrounded)
        {
            anim.SetBool(Tags.ANIM_IS_JUMPING, true);

            Vector2 jumpVelocityToAdd = new Vector2(0, jumpVelocity);

            myBody.velocity += jumpVelocityToAdd;

        }
    }

    private void Climb()
    { 
        if (!colider.IsTouchingLayers(LayerMask.GetMask(Tags.LAYER_CLIMB))) 
        {
            anim.SetBool(Tags.ANIM_IS_CLIMBING, false);
            myBody.gravityScale = gravityScale;
            return; 
        }

        float playerClimb = Input.GetAxis(Tags.MOVE_VERTICAL);

        Vector2 newPosY = new Vector2(myBody.velocity.x, playerClimb * walkSpeed);

        myBody.velocity = newPosY;
        myBody.gravityScale = 0;

        bool playerIsClimbing = Mathf.Abs(myBody.velocity.y) > Mathf.Epsilon;
        anim.SetBool(Tags.ANIM_IS_CLIMBING, playerIsClimbing);
    }

    private void FlipCharacter()
    { 

        bool flipCharacterPosition = Mathf.Abs(myBody.velocity.x) > Mathf.Epsilon;

        if (flipCharacterPosition)
        {
           transform.localScale = new Vector2(Mathf.Sign(myBody.velocity.x),1);
        }
       
    }
}
