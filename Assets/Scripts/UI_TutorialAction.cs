using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_TutorialAction : MonoBehaviour  
{
    [SerializeField] Vector3 Offset;
    TextMeshPro TutoAction;

    Transform player;
    PlantHarvester harvester;

   

    // Start is called before the first frame update
    void Start()
    {
        TutoAction = GetComponent<TextMeshPro>();
        player = GameObject.Find("Player").transform;
        harvester = player.GetComponent<PlantHarvester>();

        TutoAction.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + Offset;
        if (harvester != null) {
            if (harvester.NearbyPlant != null) {
                TutoAction.enabled = true; 
            }
            if (harvester.NearbyPlant == null)
            {
                TutoAction.enabled = false;
            }
            if (harvester.FirstPick) 
            {
                Destroy(gameObject, 1.0f);
            }
        }

    }
}
