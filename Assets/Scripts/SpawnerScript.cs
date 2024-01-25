using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public Transform[] SpawnBoxes = new Transform[3];
    public GameObject[] Enemies = new GameObject[2];
    int EnemyCount;
    int RandomEnemyNum;
    int RandomSpawnPoint;

    public GameObject Camera;
    public float duration = 1;
    public bool start;

    public GameObject ScreenEffect;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (start == true)
        {
            start = false;
            StartCoroutine(Shake());
        }
    }

    void Spawn()
    {
        EnemyCount = Random.Range(1, 4);

        for (int i = 1; i <= EnemyCount; i++)
        {
            RandomEnemyNum = Random.Range(0, 2);
            RandomSpawnPoint = Random.Range(0, 3);
            Instantiate(Enemies[RandomEnemyNum], SpawnBoxes[RandomSpawnPoint].transform.position, SpawnBoxes[RandomSpawnPoint].transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            start = true;
            ScreenEffect.SetActive(true);
            Spawn();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ScreenEffect.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator Shake()
    {
        Vector3 startPosition = Camera.gameObject.transform.position;
        float elapsedTime = 0;
        //Camera.gameObject.GetComponent<CemeraScript>().enabled = false;

        while (elapsedTime < duration)
        {
            startPosition = Camera.gameObject.transform.position;
            elapsedTime += Time.deltaTime;
            Camera.gameObject.transform.position = startPosition + Random.insideUnitSphere;
            yield return null;
        }

        //Camera.gameObject.GetComponent<CemeraScript>().enabled = true;
        Camera.gameObject.transform.position = startPosition;

    }
}
