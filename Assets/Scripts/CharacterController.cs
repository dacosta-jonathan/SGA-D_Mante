using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private Camera camera;
    [SerializeField] private TextMeshProUGUI coinNbText;
    [SerializeField] private TextMeshProUGUI deathNbText;
    
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;
    private int canJump = 0;
    private int nbDeaths = 0;
    private int nbCoins = 0;
    private Vector3 initialPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        initialPosition = transform.position;
    }
    void Update()
    {
        float crtMove = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(crtMove, rb.velocity.y);
        animator.SetFloat("speed", crtMove);
        sr.flipX = crtMove < 0;
        
        bool crtJump = Input.GetButtonDown("Jump") && canJump>0;
        if (crtJump)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            canJump--;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            canJump = 2;
        } 
    }

    public void Death()
    {
        nbDeaths++;
        deathNbText.text = nbDeaths.ToString();
        transform.position = initialPosition;
    }

    public void AddCoin()
    {
        nbCoins++;
        coinNbText.text = nbCoins.ToString();
    }
}
