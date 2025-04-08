using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;

    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource CollectedSoundEffect;
    private void OnTriggerEnter2D(Collider2D collission)
    {
        if (collission.gameObject.CompareTag("Cherry"))
        {
            CollectedSoundEffect.Play();
            Destroy(collission.gameObject);
            cherries++;
            cherriesText.text = "Points :" + cherries ;
        }

    }
}
