using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
using UnityEngine;

public class PlantHarvester : MonoBehaviour
{
    //SAC
    
    [SerializeField] TextMeshProUGUI AfficheNbFeuilleJauneSac;  
    int leafCountGreen = 0;

    [SerializeField] TextMeshProUGUI AfficheNbFeuilleVerteSac;
    int leafCountYellow = 0;

    [SerializeField] TextMeshProUGUI AfficheNbFeuilleBleuSac;
    int leafCountBlue = 0;

    

    PlantBehaviour nearbyPlant;

    bool oldKeyCollect = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Plant"))
        {
            if (other.gameObject.TryGetComponent(out PlantBehaviour plantBehaviour))
            {
                nearbyPlant = plantBehaviour;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (nearbyPlant)
        {
            if (other.gameObject == nearbyPlant.gameObject)
            {
                nearbyPlant = null;
            }
        }

    }

    private void Update()
    {
        bool keyCollect = Input.GetKey(KeyCode.E);

        if (keyCollect && !oldKeyCollect)
        {
            Harvest();
        }

        oldKeyCollect = keyCollect;

    }

    void Harvest()
    {

        /*if (nearbyPlant)
        {
            nearbyPlant.plantType
            leafCount += nearbyPlant.CollectLeaf();
            textMeshProUGUI.text = leafCount.ToString();
        } */

        if (nearbyPlant)
        {
            switch (nearbyPlant.plantType)
            {
                case PlantBehaviour.PlantType.Green:
                    leafCountGreen += nearbyPlant.CollectLeaf();
                    break;
                case PlantBehaviour.PlantType.Blue:
                    leafCountBlue += nearbyPlant.CollectLeaf();
                    break;
                case PlantBehaviour.PlantType.Yellow:
                    leafCountYellow += nearbyPlant.CollectLeaf();
                    break;
            }

            AfficheNbFeuilleVerteSac.text = leafCountGreen.ToString();
            AfficheNbFeuilleJauneSac.text = leafCountYellow.ToString();
            AfficheNbFeuilleBleuSac.text = leafCountBlue.ToString();
        }
    }
}