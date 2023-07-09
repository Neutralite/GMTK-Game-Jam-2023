using UnityEngine;

public class Block : MonoBehaviour
{
    static GameObject block;
    public static int collected;
    public void Break()
    {
        gameObject.SetActive(false);
        ObjectPoolManager.Instance.ReturnObject(gameObject);
        collected++;
    }

    public static void Build(Vector3 blockPos,Vector3 hitPos)
    { 
        Vector3 difference = hitPos - blockPos;
        if (Mathf.Abs(difference.x) == 0.5f)
        {
            difference = difference.x > 0 ? Vector3.right : Vector3.left;
        }
        if (Mathf.Abs(difference.y) == 0.5f)
        {
            difference = difference.y > 0 ? Vector3.up : Vector3.down;
        }
        if (Mathf.Abs(difference.z) == 0.5f)
        {
            difference = difference.z > 0 ? Vector3.forward : Vector3.back;
        }

        block = ObjectPoolManager.Instance.ReleaseObject(ObjectID.Snow);
        block.transform.position = blockPos+difference;
        block.SetActive(true);
        collected--;
    }
}
