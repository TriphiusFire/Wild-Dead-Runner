using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDied : MonoBehaviour
{

    public delegate void EndGame();
    public static event EndGame endGame;

    // Start is called before the first frame update
    void PlayerDiedEndGame()
    {
        if(endGame != null)
        {
            endGame();
        }
       
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        PlayerJump.landed = true;
        if(target.tag == "Collector" )
        {
            PlayerDiedEndGame();
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        PlayerJump.landed = true;
        Debug.Log("Player Collision Entered Something");
        if (target.gameObject.tag == "Zombie")
        {
            Debug.Log("Player Collision Entered Zombie");
            //gameObject.SetActive(false);
            PlayerDiedEndGame();

           
        }
    }

 

}//PlayerDied
