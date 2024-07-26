using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class coffeshop : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    [SerializeField]
    TextMeshProUGUI AfficheNbFeuilleJaune;
    [SerializeField]
    TextMeshProUGUI AfficheNbFeuilleVert;
    [SerializeField]
    TextMeshProUGUI AfficheNbFeuilleBleu;

    Dictionary<PlantBehaviour.PlantType, TextMeshProUGUI> AfficheNbFeuilleSac = new();

    private void Awake()
    {
        AfficheNbFeuilleSac[PlantBehaviour.PlantType.Yellow] = AfficheNbFeuilleJaune;
        AfficheNbFeuilleSac[PlantBehaviour.PlantType.Green] = AfficheNbFeuilleVert;
        AfficheNbFeuilleSac[PlantBehaviour.PlantType.Blue] = AfficheNbFeuilleBleu;
    }

    private Dictionary<PlantBehaviour.PlantType, int> recipe = new ();

    public void GenerateNewRecipe()
    { 
        for (int i = 0; i < 3; i++)
        {
            PlantBehaviour.PlantType plantType = (PlantBehaviour.PlantType)Random.Range(0,3);
            if(recipe.TryGetValue(plantType, out int number)){
                recipe[plantType] += number;
            } else {
                recipe[plantType] = 1;
            }
        }

        foreach(var (leafType, number) in recipe)
        {
            AfficheNbFeuilleSac[leafType].text = number.ToString();
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
    
    public bool Deposit(Dictionary<PlantBehaviour.PlantType, int> bag)
    {
        bool isValid = true;
        foreach (var (plantType, number) in recipe)
        {
            isValid = (number <= bag[plantType]) && isValid;
        }

        if (isValid)
        {
            GenerateNewRecipe();
        }

        return isValid;
    }
}
