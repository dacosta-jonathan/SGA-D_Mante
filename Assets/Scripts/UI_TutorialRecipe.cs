using UnityEngine;
using TMPro;

public class UI_TutorialRecipe : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshPro TutoRecipe;
    Transform player;
    PlantHarvester harvester;

    private ChronoUI timeForRecipe;
    private GameManager gameManager;

    void Start()
    {
        TutoRecipe = GetComponent<TextMeshPro>();
        gameManager = FindAnyObjectByType<GameManager>();
        //time

        TutoRecipe.enabled = false;
        timeForRecipe = FindAnyObjectByType<ChronoUI>();

        player = GameObject.Find("Player").transform;
        harvester = player.GetComponent<PlantHarvester>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeForRecipe.Chrono <= (gameManager.timeToLose / 2) && !harvester.FirstDeposit)
        {
            TutoRecipe.enabled = true;
        } else TutoRecipe.enabled = false;


    }
}
