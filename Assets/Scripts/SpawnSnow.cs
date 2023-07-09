using UnityEngine;

public class SpawnSnow : ISetupStep
{
    public int x, y;
    Column[] tempColumn;
    GameObject tempSnow;

    public void RunStep()
    {
        ReleaseSnow();
    }

    private void ReleaseSnow()
    {
        for (int i = -2; i < x; i++)
        {
            for (int j = -2; j < y; j++)
            {
                int temp = Random.Range(1, 4);
                for (int k = 0; k < temp; k++)
                {
                    tempSnow = ObjectPoolManager.Instance.ReleaseObject(ObjectID.Snow);
                    tempSnow.transform.position = i * Vector3.right + k * Vector3.up + 4* Vector3.up + j * Vector3.forward;
                    tempSnow.SetActive(true);
                }

            }
        }
    }
}
