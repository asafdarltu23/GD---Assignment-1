using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Connected : MonoBehaviour
{
    public Transform Characterpos;
    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = new Vector3(Characterpos.position.x, Characterpos.position.y - 0.386f, Characterpos.position.z);
    }
}
