using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;

    [SerializeField] private Text cherriesText;

    private void OnTriggerEnter2D(Collider2D collission)
    {
        if (collission.gameObject.CompareTag("Cherry"))
        {
            Destroy(collission.gameObject);
            cherries++;
            cherriesText.text = "Points :" + cherries ;
        }

    }
}
