using UnityEngine;
using System.Collections.Generic;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject tile = null;

    [SerializeField] private float offsetX = 0.0f;
    [SerializeField] private float offsetY = 0.0f;

    [SerializeField] private int height = 10;
    [SerializeField] private int width = 10;

    private List<GameObject> tiles = null;

    public void Generate()
    {
        if (tiles == null)
            tiles = new List<GameObject>();

        Clear();

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                tiles.Add(Instantiate(tile, new Vector2(-8.5f + (j * 0.6f) + offsetX, -4.6f + (i * 0.6f) + offsetY), Quaternion.identity));
            }
        }
    }

    public void Clear()
    {
        if (tiles == null)
            tiles = new List<GameObject>();

        foreach (GameObject _tile in tiles)
        {
            if(_tile != null)
                DestroyImmediate(_tile);
        }

        tiles.Clear();
    }
}
