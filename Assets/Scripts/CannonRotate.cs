using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotate : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        /*Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; 
        float angle =  Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;  */
        
        
        
        Vector3 mousepos = Input.mousePosition;
        mousepos.z = 5.23f;

        Vector3 objectpos = Camera.main.WorldToScreenPoint(transform.position);
        mousepos.x = mousepos.x - objectpos.x;
        mousepos.y = mousepos.y - objectpos.y;

        float angle = Mathf.Atan2(mousepos.y, mousepos.x) * Mathf.Rad2Deg;
        if (!Pause.isPaused)
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        
    }
}
