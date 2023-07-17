using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float speed;
    public int health;

    private Rigidbody2D rb;

    private Vector2 moveInput;
    private Vector2 moveVelocity;

    public Text healthDisplay;

    public Text deathDisplay;
    public Button button;
 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
            healthDisplay.gameObject.SetActive(false);
            deathDisplay.gameObject.SetActive(true);
            button.gameObject.SetActive(true);
            
        }
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    public void Damaged(int damage)
    {
        health -= damage;
        healthDisplay.text = "HP: " + health;
    }
}
