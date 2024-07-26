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


    coffeshop nearbyShop;

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

        if (other.gameObject.CompareTag("CoffeeShop"))
        {
            if (other.gameObject.TryGetComponent(out coffeshop cs))
            {
                nearbyShop = cs;
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

        if (nearbyShop && other.gameObject.CompareTag("CoffeeShop"))
        {
            nearbyShop = null;
        }
    }

    private void Update()
    {
        bool interact = Input.GetKey(KeyCode.E);

        if (interact && nearbyPlant != null && !oldKeyCollect)
        {
            Harvest();
        }

        if (interact && nearbyShop != null && !oldKeyCollect)
        {
            DropBag();
        }

        oldKeyCollect = interact;

    }

    void DropBag() 
    {
        if (nearbyShop)
        {
            Dictionary<PlantBehaviour.PlantType, int> bag = new();
            bag[PlantBehaviour.PlantType.Green] = leafCountGreen;
            bag[PlantBehaviour.PlantType.Yellow] = leafCountYellow;
            bag[PlantBehaviour.PlantType.Blue] = leafCountBlue;
            nearbyShop.Deposit(bag);
            leafCountGreen = 0;
            leafCountYellow = 0;
            leafCountBlue = 0;

            AfficheNbFeuilleVerteSac.text = leafCountGreen.ToString();
            AfficheNbFeuilleJauneSac.text = leafCountYellow.ToString();
            AfficheNbFeuilleBleuSac.text = leafCountBlue.ToString();
        }
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