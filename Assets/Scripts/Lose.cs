using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    GameObject player;
    public AudioSource audioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Death.dead == true)
        {
            while (audioPlayer.isPlaying == false)
            {
                audioPlayer.Play();
            }
         
            StartCoroutine(Load());
        }
    }

    IEnumerator Load()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("LoseScreen");
    }
}
