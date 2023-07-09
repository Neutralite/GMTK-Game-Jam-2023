using UnityEngine;

public class Block : MonoBehaviour
{
    static GameObject block;
    [SerializeField] bool breakable;

    public void Break()
    {
        if (breakable)
        {
            gameObject.SetActive(false);
            ObjectPoolManager.Instance.ReturnObject(gameObject);
            IceManager.Instance.Ice++;
        }
    }

    public static void Build(Vector3 blockPos,Vector3 hitPos)
    {
        print(blockPos);
        print(hitPos);
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

        Vector3 newPos = blockPos + difference;
        
        // Cast a box to see if the player is standing where the block could be
        if (!Physics.BoxCast(newPos+Vector3.up*2,Vector3.one/2,Vector3.down,Quaternion.identity,1,1<<3))
        {
            block = ObjectPoolManager.Instance.ReleaseObject(ObjectID.Snow);
            block.transform.position = newPos;
            block.SetActive(true);
            IceManager.Instance.Ice--;
        }
    }
}
