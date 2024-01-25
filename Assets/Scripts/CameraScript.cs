using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    GameObject Player;
    public float xMin;
    public float yMin;
    public float xMax;
    public float yMax;
   // float currentpos;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Clamp(Player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(Player.transform.position.y, yMin, yMax);
        //currentpos = this.gameObject.transform.position.x;

        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);

    }
}
