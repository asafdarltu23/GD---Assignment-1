using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    bool canFire;
    public static bool notAllowedToFire;
    float timer;
    public float cooldown;
    public GameObject projectile;
    public Transform projectileTransform;
    
    public AudioSource audioPlayer;
    public AudioClip sound;
    // Start is called before the first frame update
    void Start()
    {
        audioPlayer.clip = sound;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > cooldown)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetKey(KeyCode.Mouse0) && canFire && !notAllowedToFire && !Pause.isPaused) 
        {
            canFire = false;
            audioPlayer.Play();
            Instantiate(projectile, projectileTransform.position, Quaternion.identity);
        }
    }
}
