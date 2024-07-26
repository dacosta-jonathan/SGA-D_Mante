using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coffeshop : MonoBehaviour
{

    // récupérer rigid body
    // vérifier si collision avec joueur (avec coffeshop)
    // si oui : comparer le sac (dans PlantHarvester) à la reciepe
    // 

    private PlantBehaviour.PlantType[] recipe = new PlantBehaviour.PlantType[3];

    public void GenerateNewRecipe()
    { 
        for (int i = 0; i < recipe.Length; i++)
        {
            int val = Random.Range(0,3);
            recipe[i] = (PlantBehaviour.PlantType)val;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateNewRecipe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
