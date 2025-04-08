using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private AudioSource DeathSoundEffect;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Xử lý sự kiện va chạm với bẫy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Nếu như Tag là Trap thì thực hiện phương thức Die
        if (collision.gameObject.CompareTag("Trap"))
        {
            DeathSoundEffect.Play();
            Die();
        }
    }

    private void Die()
    {
        
        // Ngăn nhân vật chuyển động
        rb.bodyType = RigidbodyType2D.Static;
        // Thực hiện animation death
        anim.SetTrigger("death");
    }

    // Tạo phương thức khởi tạo lại màn chơi
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}