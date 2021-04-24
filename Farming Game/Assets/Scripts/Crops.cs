using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crops : MonoBehaviour
{
    public GameManager gameManager;
    private float Timer;
    private Farmland farmland;
    private void Awake()
    {
        farmland = GetComponent<Farmland>();
        gameManager = farmland.gameManager;
        farmland.spriteRenderer.sprite = gameManager.Stage1;
        Timer = CalculateGrowTime();
    }
    public int Stage;
    // Update is called once per frame
    void Update()
    {
        Timer -= 1 * Time.deltaTime;
        if (Timer < 0)
        {
            Stage++;
            UpdateSprite();
            Timer = CalculateGrowTime();
        }
    }

    private void UpdateSprite()
    {
        if(Stage == 1)
        {
            farmland.spriteRenderer.sprite = gameManager.Stage2;
        }
        else if (Stage == 2)
        {
            farmland.spriteRenderer.sprite = gameManager.Stage3;
        }
    }

    public int CalculateGrowTime()
    {
        int time = Random.Range(5, 20);
        return time;
    }
    public int Harvest()
    {
        Destroy(GetComponent<Crops>());
        return Stage;
    }
}
