using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //to use button (etc) in script

public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    private AudioClip jumpClip;

    public AudioSource audiosource;

    private float jumpForce = 11f;
    private float forwardForce = 0f;  // at start of game

    private Rigidbody2D myBody;

    private bool canJump;

    private Button jumpBtn;

    public static bool landed;

    private bool canBoostForward;

    private bool canDropDown;

    //initialize variables in awake function
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();

        //find the jump button
        jumpBtn = GameObject.Find("Jump Button").GetComponent<Button>();

        //add a click listener to the button
        jumpBtn.onClick.AddListener(() => Jump());

        landed = true;

        canBoostForward = false;

        canDropDown = false;
    }

  

  

    public void Jump()
    {
        audiosource.PlayOneShot(jumpClip);
        //check if we can actually jump
        if (PlayerJump.landed)
        {
            PlayerJump.landed = false;
            canBoostForward = true;

            //AudioSource.PlayClipAtPoint(jumpClip, transform.position);

            if (transform.position.x < 0) //player gets its left side to middle of screen at best "forward" position
            {
                forwardForce = 1f;
            }
            else
            {
                forwardForce = 0f;
            }
            myBody.velocity = new Vector2(forwardForce, jumpForce);

        }
        else if(canBoostForward)
        {
            canDropDown = true;
            canBoostForward = false;
            forwardForce = 6f;
            myBody.velocity = new Vector2(forwardForce, 3f);
        }
        else if(canDropDown)
        {
            canDropDown = false;
            myBody.velocity = new Vector2(0, -8f);
        }
        

    }


}//Player Jump
