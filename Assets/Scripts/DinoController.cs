using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    private Rigidbody2D dinoRb;
    private Animator dinoAnimator;
    private AudioSource dinoAudio;
    private bool onGround = true;
    private bool isDead = false;

    public AudioClip jumpClip;
    public AudioClip damageClip;
    public float jumpForce = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        dinoRb = GetComponent<Rigidbody2D>();
        dinoAnimator = GetComponent<Animator>();
        dinoAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && onGround && !isDead)
        {
            dinoRb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            dinoAnimator.SetBool("Leap", true);
            dinoAudio.PlayOneShot(jumpClip);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            dinoAnimator.SetBool("Leap", false);
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isDead = true;
            dinoAnimator.SetBool("Dead", true);
            dinoAudio.PlayOneShot(damageClip);
            GameManager.Instance.gameOver = true;
            GameManager.Instance.gameOverObj.SetActive(true);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }
}
