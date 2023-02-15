using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private LayerMask platformLayerMask;
    public Rigidbody2D rb;
    public Vector2 moveVector;
    public float Speed = 1f;
    public float accSpeed = 1.5f;
    public float JumpForce = 5f;
    private bool Switch = true;
    private CapsuleCollider2D capsuleCollider2D;
    private Animator animator;
    private bool FacingRight = true;
    private bool isFacingRight = true;
    private bool isCharacterCanWalk = true;
    private bool isInAir = false;


    public Vector3 characterScreenPos;
    public Camera cam;
    public bool IsCharacterCanWalk
    {
        get
        {
            return isCharacterCanWalk;
        }
        set
        {
            isCharacterCanWalk = value;
        }
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        platformLayerMask = LayerMask.GetMask("Platform");
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        characterScreenPos = Camera.main.WorldToScreenPoint(transform.position);

        FlipCharacter();
        Jump();

        if (isOnGround() && isInAir)
        {
            isInAir = false;
            animator.SetTrigger("isJustGrounded");


        }

        if (isCharacterCanWalk)
        {
            Walk();
        }
        // Debug.DrawRay(new Vector2(capsuleCollider2D.bounds.min.x, capsuleCollider2D.bounds.min.y), Vector2.down * 0.1f, Color.blue);
        // Debug.DrawRay(new Vector2(capsuleCollider2D.bounds.max.x, capsuleCollider2D.bounds.min.y), Vector2.down *  0.1f, Color.blue);
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        onFeetCollider = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        onFeetCollider = false;
    }*/

    void Walk()
    {

        moveVector.x = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(moveVector.x) * Speed);



        rb.velocity = new Vector2(Speed * moveVector.x, rb.velocity.y);

        if (Input.GetKey(KeyCode.LeftShift) && Switch == true && Mathf.Abs(rb.velocity.x) > 0 && isOnGroundLeft() == true)
        {

            Speed = accSpeed;
            Switch = false;
        }

        if (rb.velocity.x == 0 && Switch == false)
        {
            Speed = 1f;
            Switch = true;
        }

    }
    void Jump()
    {


        if (Input.GetKeyDown(KeyCode.Space) && isOnGround())
        {
            animator.Play("New jump fast");
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            StartCoroutine(SetBoolTrueAfterSecs(0.5f));


        }
    }
    private bool isOnGround()
    {
        if (isOnGroundLeft() || isOnGroundRight())
            return true;
        else
            return false;
    }
    private bool isOnGroundLeft()
    {
        float additionalHeightValue = 0.1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(new Vector2(capsuleCollider2D.bounds.min.x, capsuleCollider2D.bounds.center.y), Vector2.down, capsuleCollider2D.bounds.extents.y + additionalHeightValue, platformLayerMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(new Vector2(capsuleCollider2D.bounds.min.x, capsuleCollider2D.bounds.min.y), Vector2.down * additionalHeightValue, rayColor);
        return raycastHit.collider != null;
    }
    IEnumerator SetBoolTrueAfterSecs(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        isInAir = true;
    }

    private bool isOnGroundRight()
    {
        float additionalHeightValue = 0.1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(new Vector2(capsuleCollider2D.bounds.max.x, capsuleCollider2D.bounds.center.y), Vector2.down, capsuleCollider2D.bounds.extents.y + additionalHeightValue, platformLayerMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(new Vector2(capsuleCollider2D.bounds.max.x, capsuleCollider2D.bounds.min.y), Vector2.down * additionalHeightValue, rayColor);
        return raycastHit.collider != null;
    }

    /* private bool isNearWall() //ФИКСИТЬ
     {
         float additionalValue = 0.001f;
         RaycastHit2D raycastHit = Physics2D.Raycast(capsuleCollider2D.bounds.center, Vector2.right, capsuleCollider2D.bounds.extents.y, platformLayerMask);
         Color rayColor;
         if (raycastHit.collider != null)
         {
             rayColor = Color.red;
         }
         else
         {
             rayColor = Color.green;
         }
         Debug.DrawRay(capsuleCollider2D.bounds.center, Vector2.right* (capsuleCollider2D.bounds.extents.y ), rayColor);
         return raycastHit.collider != null;
     }*/
    private void FlipCharacter()
    {
        if (moveVector.x < 0 && FacingRight)
        {
            Flip();
            isFacingRight = false;
        }
        else
            if (moveVector.x > 0 && !FacingRight)
        {
            Flip();
            isFacingRight = true;
        }
    }
    private void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

}


