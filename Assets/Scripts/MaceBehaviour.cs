using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MaceBehaviour : MonoBehaviour
{
    enum Phase
    {
        Idle,
        Attack,
        Return
        
    }

    [SerializeField] private GameObject player;
    
    private Vector3 initialPosition;
    private Rigidbody2D rb2d;
    private Phase currentPhase = Phase.Idle;
    
    
    void Start()
    {
        initialPosition = transform.position;
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (currentPhase == Phase.Idle)
        {
            if (player.transform.position.x > transform.position.x - 0.5 &&
                player.transform.position.x < transform.position.x + 0.5)
            {
                currentPhase = Phase.Attack;
            }
        }

        if (currentPhase == Phase.Attack)
        {
            rb2d.gravityScale = 1;
        }

        if (currentPhase == Phase.Return)
        {
            rb2d.gravityScale = 0;
            rb2d.velocity = Vector2.zero;
            transform.position = Vector3.Slerp(transform.position, initialPosition, 0.1f);
            if (Vector3.Distance(transform.position, initialPosition) < 0.01f)
            {
                currentPhase = Phase.Idle;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            col.gameObject.GetComponent<CharacterController>().Death();
        }

        if (col.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            currentPhase = Phase.Return;
        }
    }
}
