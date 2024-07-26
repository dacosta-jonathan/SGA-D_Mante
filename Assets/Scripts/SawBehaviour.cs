using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBehaviour : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = -10;

    private void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles+new Vector3(0,0,rotationSpeed*Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            col.gameObject.GetComponent<CharacterController>().Death();
        }
    }
}
