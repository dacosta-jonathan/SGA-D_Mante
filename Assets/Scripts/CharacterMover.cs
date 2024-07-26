using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMover : MonoBehaviour
{
    [SerializeField] float heighOffset = 0.5f;
    [SerializeField] float Vit = 5;
    [SerializeField] float hurtSpeed = 2.5f;
    [SerializeField] float hurtTotalTime = 1.0f;
    [SerializeField] private LayerMask rayCastMask;

    [SerializeField] private Animator animator;

    Vector3 finalPos;
    Rigidbody rb;
    bool isMoving = false;
    bool isHurt = false;

    float hurtTimer = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        finalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            finalPos = ReturnRaycastPositionOnClick();
            isMoving = true;
            transform.LookAt(finalPos);
        }
        //transform.position = Vector3.Lerp(transform.position, finalPos, Time.deltaTime);
        
        if (isMoving)
        {
            Vector3 positionToTarget = (finalPos - transform.position);

            rb.velocity = positionToTarget.normalized * (isHurt ? hurtSpeed : Vit);


            if (positionToTarget.magnitude <= 0.1)
            {
                isMoving = false;
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
        }

        hurtTimer -= Time.deltaTime;
        if (hurtTimer <= 0)
        {
            isHurt = false;
        }

        animator.SetFloat("speed", rb.velocity.magnitude);
    }

    public void Hurt()
    {
        isHurt = true;
        hurtTimer = hurtTotalTime;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;

    //    Ray ray;
    //    ray.origin = Camera.main.transform.position;
    //    ray.direction = 

    //    Gizmos.DrawRay(Camera.main.transform.position, transform.forward);
    //}

    /// <summary>
    /// Method to return Vector3 from raycast
    /// </summary>
    private Vector3 ReturnRaycastPositionOnClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, rayCastMask.value))
        {
            //if (raycastHit.collider.CompareTag("Ground"))
            {
                Vector3 pos = raycastHit.point;
                pos = new Vector3(
                    pos.x,
                    pos.y + heighOffset,
                    pos.z);
                return pos;
            }
        }
        return transform.position;
    }

    
}
