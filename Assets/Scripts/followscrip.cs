using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class followscrip : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;

    [SerializeField] NavMeshAgent agent;

    Transform target;
    //private Vector3 Direction;
    Rigidbody rb;

    Vector3 finalPos;

    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

       
        //ransform.LookAt(target);

        agent.SetDestination(target.position);
        agent.speed = speed;

        //Vector3 direction = (target.transform.position - transform.position).normalized;
        //rb.velocity = direction * speed;

        //transform.position += Vector3.MoveTowards(this.transform.position, target.position, 1) * Time.deltaTime;
    }
}
