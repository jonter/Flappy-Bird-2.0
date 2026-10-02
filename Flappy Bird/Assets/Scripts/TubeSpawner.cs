using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeSpawner : MonoBehaviour
{
    [SerializeField] GameObject tubesPrefab;
    [SerializeField] float timeBetween = 2.5f;
    [SerializeField] float tubeSpeed = 1;
    [SerializeField] float randomY = 2;

    bool isActive = false;    

    public void StartSpawning()
    {
        if (isActive == true) return;
        isActive = true;
        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(timeBetween);
        GameObject clone = Instantiate(tubesPrefab);
        float r = Random.Range(-randomY, randomY);
        clone.transform.position = transform.position + new Vector3(0, r, 0);
        clone.GetComponent<Mover>().speed = tubeSpeed;

        StartCoroutine(SpawnCoroutine());
    }

    
}
