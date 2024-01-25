using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public static int health;
    public static bool dead;
    public Transform explosion;
    public GameObject Cannon;

   // public AudioSource audioPlayer;
    //public AudioClip sound;

    //public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //Instance = this;
        // audioPlayer.clip = sound;
        health = 3;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 1)
        {
            dead = true;
            
        }
        if (dead == true)
        {
            /*if(audioPlayer.isPlaying == false)
            {
                print("dead");
                audioPlayer.Play();
            }
            animator.SetBool("isDead", true);*/
            
            Kill();
        }
    }

    
    public void Kill()
    {
        Debug.Log("DEAD");
        Instantiate(explosion, this.transform.position, this.transform.rotation);
        //ANIMATION

        Destroy(gameObject);
        Destroy(Cannon);

    }
}
