using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class GameManager : MonoBehaviour
{
    public GameObject Tilemap;
    public Farmland[] Tiles;
    public string DataPath;
    private void Awake()
    {
        DataPath = Application.dataPath + "/TileSaves/";
        Directory.CreateDirectory(DataPath);
    }
    public enum Tool
    {
        None,
        Hoe,
        Shovel,
        Seeds
    }
    public void SaveTiles()
    {
        for (int i = 0; i < Tiles.Length; i++)
        {
            Tiles[i].Save();
        }
    }
    public void LoadTiles()
    {
        for (int i = 0; i < Tiles.Length; i++)
        {
            
            Tiles[i].Load();
        }
    }
    public Sprite Farmland;
    public Sprite Grass;
    public Sprite Dirt;
    public Sprite Stage1;
    public Sprite Stage2;
    public Sprite Stage3;
    public Tool SelectedTool;
    public Texture2D Hoe;
    public Texture2D Shovel;
    public Texture2D DefaultCursor;
    // Start is called before the first frame update
    void Start()
    {
        TilesReference();
    }
    public void TilesReference()
    {
        Tiles = null;
        Tiles = Tilemap.transform.GetComponentsInChildren<Farmland>();
        for (int i = 0; i < Tiles.Length; i++)
        {
            Tiles[i].id = i;
        }
    }
    public void SelectNone()
    {
        SelectedTool = Tool.None;
        Cursor.SetCursor(DefaultCursor, Vector2.zero, CursorMode.Auto);
    }
    public void Selectbasket()
    {
        SelectedTool = Tool.Seeds;
        Cursor.SetCursor(DefaultCursor, Vector2.zero, CursorMode.Auto);
    }
    public void SelectHoe()
    {
        SelectedTool = Tool.Hoe;
        Cursor.SetCursor(Hoe, Vector2.zero, CursorMode.Auto);
    }
    public void SelectShovel()
    {
        SelectedTool = Tool.Shovel;
        Cursor.SetCursor(Shovel, Vector2.zero, CursorMode.Auto);
    }
    // Update is called once per frame
    void Update()
    {

    }
}