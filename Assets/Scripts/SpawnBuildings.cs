using UnityEngine;

public class SpawnBuildings : ISetupStep
{
    public int x, y;
    Column[] tempColumn;
    GameObject tempBuilding;

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

            }
        }
    }
}
