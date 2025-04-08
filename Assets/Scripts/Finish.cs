using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishsound;

    private bool CompletedLevel = false;

    private void Start()
    {
        finishsound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision) //xét va chạm vạch đích
    {
        if(collision.gameObject.name == "Player" && !CompletedLevel)
        {
            finishsound.Play();
            CompletedLevel = true;
            Invoke("CompleteLevel", 2f);
        }
    }
    private void CompleteLevel()    // chuyển cảnh
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
