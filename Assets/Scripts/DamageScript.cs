using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public float invulnerabilitytime;
    float timer;
    bool canHurt = true;

    public int delay = 100;
    public GameObject particles;
    public Animator animator;
    //int counter;
    //bool toggle = false;

    public AudioSource audioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!canHurt)
        {
            animator.SetBool("Hurt", true);
            particles.SetActive(true);
            ShootingScript.notAllowedToFire = true;
            if (audioPlayer.isPlaying == false)
            {
                audioPlayer.Play();
            }
            timer += Time.deltaTime;
            if (timer > invulnerabilitytime)
            {
                canHurt = true;
                timer = 0;
                particles.SetActive(false);
                animator.SetBool("Hurt", false);
                ShootingScript.notAllowedToFire = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && canHurt)
        {
            Hurt();
        }

        if (other.CompareTag("Trap") && canHurt)
        {
            Hurt();
        }
    }

   /* void Flash(SpriteRenderer sprite)
    {
        if(counter > delay && Death.health > 1)
        {
            counter = 0;
            toggle = !toggle;

            if (toggle)
            {
                sprite.enabled = true;
            }
            else
            {
                sprite.enabled = false;
            }
        }
        else
        {
            counter++;
        }
    }*/
    void Hurt()
    {
        Death.health = Death.health - 1;
        canHurt = false;
    }
}
