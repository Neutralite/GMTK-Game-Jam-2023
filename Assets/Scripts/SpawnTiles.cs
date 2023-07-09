using UnityEngine;

public class SpawnTiles : ISetupStep
{
    public int x, y;
    Column[] tempColumn;
    GameObject tempTile;
    public void RunStep()
    {
        PrepareGrid();
        ReleaseTiles();
    }
    void PrepareGrid()
    {
        tempColumn = new Column[x];
        for (int i = 0; i < x; i++)
        {
            tempColumn[i].row = new GameObject[y];
        }
    }
    void ReleaseTiles()
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                PickTile();
                tempTile.transform.position = 5 * i * Vector3.right + Vector3.zero + 5 * j * Vector3.forward;
                tempTile.SetActive(true);
                tempColumn[i].row[j] = tempTile;
            }
        }
        TileGrid.Instance.column = tempColumn;
    }

    void PickTile()
    {
        tempTile = ObjectPoolManager.Instance.ReleaseObject((ObjectID)Random.Range(0,11));
    }
}
