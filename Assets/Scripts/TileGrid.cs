using System;
using UnityEngine;

public class TileGrid:MonoBehaviour
{
    public static TileGrid Instance { get; private set; }
    public int xWidth, zLength;
    public Column[] column;

    private void Awake()
    {
        Instance = null;
        Instance = this;
    }
}
[Serializable]
public struct Column
{
    public GameObject[] row;
}