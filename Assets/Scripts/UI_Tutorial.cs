using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Tutorial : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextTutorial;
    CharacterMover character;
    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindFirstObjectByType<CharacterMover>();

    }

    // Update is called once per frame
    void Update()
    {
        if (character.IsMoving) 
        {
            Destroy(gameObject, 1.0f);
        }
    }
}
