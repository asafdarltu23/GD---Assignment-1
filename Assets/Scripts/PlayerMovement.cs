using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform Cannon;

    //public Animator animator;

    //public AudioSource audioPlayer;
    //public AudioClip sound;

    public Rigidbody2D body;
    //public float jumpForce;
    public float speed;

    public float minFloorDistance;
    public Vector3 raycastOriginOffset;
    public float distanceBetweenRays;

    [SerializeField]
    private bool physicsMovement = true;
    [SerializeField]
    bool raw;

    bool facingRight = true;
    void Start()
    {
        body = this.gameObject.GetComponent<Rigidbody2D>();
        //audioPlayer.clip = sound;
    }

    // Update is called once per frame
    void Update()
    {

        if (physicsMovement)
        {
            PhysicsMovement();
            if (!Physics2D.Raycast(this.transform.position + raycastOriginOffset, -Vector2.up, minFloorDistance) && Death.dead == false)
            {
                //animator.SetBool("isJumping", true);
            }

            if (Physics2D.Raycast(this.transform.position + raycastOriginOffset, -Vector2.up, minFloorDistance) || Death.dead == true)
            {
                //animator.SetBool("isJumping", false);
            }
        }

        else
        {
            KinemeticMovement();
        }
    }

    void KinemeticMovement()
    {

    }

    void PhysicsMovement()
    {
        

        Debug.DrawRay(this.transform.position + raycastOriginOffset,
            -Vector2.up * minFloorDistance, Color.red);

        bool middleRay = Physics2D.Raycast(this.transform.position + raycastOriginOffset,
            -Vector2.up * minFloorDistance);
        bool leftRay = Physics2D.Raycast(this.transform.position + raycastOriginOffset - Vector3.right * distanceBetweenRays,
            -Vector2.up * minFloorDistance);
        bool rightRay = Physics2D.Raycast(this.transform.position + raycastOriginOffset + Vector3.right * distanceBetweenRays,
            -Vector2.up * minFloorDistance);

        float xMov = Input.GetAxis("Horizontal");
        float yMov = Input.GetAxis("Vertical");
        //if (raw)
        //{
          //  xMov = Input.GetAxis("Raw");
        //}
        //else
        //{
          //  xMov = Input.GetAxis("Horizontal");
        //}
        
        body.velocity = new Vector2(xMov * speed, yMov * speed);

        /*if (Input.GetButtonDown("Jump"))
        {
            if (Physics2D.Raycast(this.transform.position + raycastOriginOffset, -Vector2.up, minFloorDistance))
            {
                //audioPlayer.Play();
                body.AddForce(Vector2.up * jumpForce * 10);
            }
        }*/
        
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousepos.x > gameObject.transform.position.x && facingRight == false && !Pause.isPaused)
        {
            facingRight = !facingRight;
            Vector2 localscale = gameObject.transform.localScale;
            localscale.x *= -1;
            transform.localScale = localscale;
        }
        else if (mousepos.x < gameObject.transform.position.x && facingRight == true && !Pause.isPaused)
        {
            facingRight = !facingRight;
            Vector2 localscale = gameObject.transform.localScale;
            localscale.x *= -1;
            transform.localScale = localscale;
        }

        //animator.SetFloat("Speed", Mathf.Abs(xMov * speed));
    }
}
