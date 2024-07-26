using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animeSquash : MonoBehaviour
{

    [SerializeField]
    float rotSpeed = 2;

    [SerializeField]
    float maxRotAngle = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, Mathf.Sin(Time.time * rotSpeed) * (maxRotAngle / 180 * Mathf.PI));
        Debug.Log(Mathf.Sin(Time.deltaTime * rotSpeed) * (maxRotAngle / 180 * Mathf.PI));
    }
}
