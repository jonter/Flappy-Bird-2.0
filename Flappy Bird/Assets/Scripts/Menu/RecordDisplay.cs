using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecordDisplay : MonoBehaviour
{
    
    void Start()
    {
        int record = PlayerPrefs.GetInt("record");
        if(record == 0)
        {
            GetComponent<TMP_Text>().text = "Рекорда нет";
        }
        else
        {
            GetComponent<TMP_Text>().text = "Рекорд: " + record;
        }
    }

    
}
