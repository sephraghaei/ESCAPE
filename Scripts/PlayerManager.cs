using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public GameObject player;
    public float jumpForce;
    private Rigidbody2D rb;
    public GameManager gameManager;
    private bool isJumping;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerJump();
        }

        if (rb.position.y < -5f)
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }

    public void playerJump()
    {
        if(!isJumping)
        {
            rb.velocity = Vector2.up * jumpForce;
            isJumping = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Spike")
        {
            gameManager.GameOver();
            Destroy(gameObject);
        }

        if(col.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Crystal")
        {
            gameManager.UpdateScore();
            Destroy(hit.gameObject);
        }

        if (hit.gameObject.tag == "FinishCrystal")
        {
            gameManager.GameComplete();
            Destroy(hit.gameObject);
        }

        // if (hit.gameObject.tag == "FinishCoin")
        // {
        //gameManager.GameComplete();
        //Destroy(hit.gameObject);
        // }
    }
}
