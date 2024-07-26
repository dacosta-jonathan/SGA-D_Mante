using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtOnHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.TryGetComponent(out CharacterMover mover))
            {
                mover.Hurt();
            }
        }
    }
}
