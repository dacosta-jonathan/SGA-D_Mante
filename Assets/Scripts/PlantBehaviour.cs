using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBehaviour : MonoBehaviour
{
    public enum PlantType
    {
        Green,
        Blue,
        Yellow,
    }

    [SerializeField] int currentNumberOfLeaves = 3;
    [SerializeField] GameObject leafOne;
    [SerializeField] GameObject leafTwo;
    [SerializeField] GameObject leafThree;
    //type de la plante
    [SerializeField] public PlantType plantType = PlantType.Green;


    public int CollectLeaf()
    {
        if (currentNumberOfLeaves <= 0)
        {
            return 0;
        }

        currentNumberOfLeaves--;

        if (currentNumberOfLeaves == 0)
        {
            leafOne.SetActive(false);
            leafTwo.SetActive(false);
            leafThree.SetActive(false);
        }

        if (currentNumberOfLeaves == 1)
        {
            leafOne.SetActive(false);
            leafTwo.SetActive(false);
            leafThree.SetActive(true);
        }

        if (currentNumberOfLeaves == 2)
        {
            leafOne.SetActive(false);
            leafTwo.SetActive(true);
            leafThree.SetActive(true);
        }

        if (currentNumberOfLeaves == 3)
        {
            leafOne.SetActive(true);
            leafTwo.SetActive(true);
            leafThree.SetActive(true);
        }

         return 1;
    }
}
