using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Obstacle")
        {
            anim.Play("Idle");
        }
    }

    void OnCollisionExit2D(Collision2D target)
    {
        if (target.gameObject.tag == "Obstacle")
        {
            anim.Play("Run");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
