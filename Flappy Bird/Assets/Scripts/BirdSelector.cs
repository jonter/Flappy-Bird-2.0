using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSelector : MonoBehaviour
{
    [SerializeField] GameObject[] birds;
    // Start is called before the first frame update
    void Start()
    {
        int num = PlayerPrefs.GetInt("bird");
        BirdController b = FindAnyObjectByType<BirdController>();
        Vector3 pos = b.transform.position;

        Destroy(b.gameObject);
        GameObject clone = Instantiate(birds[num]);
        clone.transform.position = pos;
    }

    
}
