using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.IO;
public class Farmland : MonoBehaviour
{
    public enum LandState
    {
        Grass,
        Dirt,
        FarmLand,
        FarmLand_State01,
        FarmLand_State02,
        FarmLand_State03,
    }
    public int Index;
    public FarmlandData Data;
    public SpriteRenderer spriteRenderer;
    public GameManager gameManager;
    public void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        switch (gameManager.SelectedTool)
        {
            case GameManager.Tool.None:
                break;
            case GameManager.Tool.Hoe:
                spriteRenderer.sprite = gameManager.Farmland;
                Data.landState = LandState.FarmLand;
                break;
            case GameManager.Tool.Shovel:
                if(spriteRenderer.sprite == gameManager.Grass)
                {
                    spriteRenderer.sprite = gameManager.Dirt;
                    Data.landState = LandState.Dirt;
                }
                else
                {
                    spriteRenderer.sprite = gameManager.Grass;
                    Data.landState = LandState.Grass;
                }
                break;
            case GameManager.Tool.Seeds:
                if (Data.landState != LandState.FarmLand) return;
                gameObject.AddComponent<Crops>();
                Data.landState = LandState.FarmLand_State01;
                break;
            default:
                break;
        }
    }
    public int id;
    public string DataPath;
    public void Save()
    {
        string json = JsonUtility.ToJson(Data);
        File.WriteAllText(DataPath + "/saveFile.json", json);
        Debug.Log("Saved");
    }
    public void Load()
    {
            string load = File.ReadAllText(DataPath + "/saveFile.json");
            Data = JsonUtility.FromJson<FarmlandData>(load);
            Debug.Log(Data.landState);
            switch (Data.landState)
            {
                case LandState.Grass:
                    spriteRenderer.sprite = gameManager.Grass;
                    break;
                case LandState.Dirt:
                    spriteRenderer.sprite = gameManager.Dirt;
                    break;
                case LandState.FarmLand:
                    spriteRenderer.sprite = gameManager.Farmland;
                    break;
                case LandState.FarmLand_State01:
                    break;
                case LandState.FarmLand_State02:
                    break;
                case LandState.FarmLand_State03:
                    break;
            }
        
    }
    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        DataPath = gameManager.DataPath + $"Tile_{id}/";
        gameManager.TilesReference();
        Directory.CreateDirectory(DataPath);
        spriteRenderer = GetComponent<SpriteRenderer>();
        Load();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public class FarmlandData
{
    public Farmland.LandState landState;
}
