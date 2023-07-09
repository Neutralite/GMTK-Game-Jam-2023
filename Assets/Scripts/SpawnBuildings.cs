using UnityEngine;

public class SpawnBuildings : ISetupStep
{
    public int x, y;

    public void RunStep()
    {
        ReleaseBuildings();
    }

    private void ReleaseBuildings()
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                TileGrid.Instance.column[i].row[j].GetComponent<Tile>().SpawnBuildings();
            }
        }
    }
}
