using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIScript : MonoBehaviour
{
    public GameObject HeartDisplay3;
    public GameObject HeartDisplay2;
    public GameObject HeartDisplay1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Death.health == 2)
        {
            HeartDisplay3.SetActive(false);
        }

        if(Death.health == 1)
        {
            HeartDisplay2.SetActive(false);
        }

        if(Death.health == 0) 
        { 
            HeartDisplay1.SetActive(false);
        }
    }
}
