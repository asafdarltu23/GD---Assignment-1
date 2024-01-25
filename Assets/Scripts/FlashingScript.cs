using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingScript : MonoBehaviour
{
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Wait();
    }

    IEnumerator Wait()
    {
        obj.SetActive(false);
        yield return new WaitForSeconds(1);
        obj.SetActive(true);
    }
}
