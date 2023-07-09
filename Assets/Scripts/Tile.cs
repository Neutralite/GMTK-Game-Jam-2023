using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool N, W, E, S;
    [SerializeField]
    GameObject[] buildingsA, buildingsB;
    public void SpawnBuildings()
    {
        for (int i = 0; i < buildingsA.Length; i++)
        {
            int temp = Random.Range(1, 10);
            if (temp>6)
            {
                buildingsA[i].SetActive(true);
            }
            else
            {
                buildingsB[i].SetActive(true);

            }
        }

    }
}
