using UnityEngine;

public class ObjectDetection : MonoBehaviour
{
    // Bit shift the index of the layer to get a bit mask
    int snowLayer = 1 << 6;

    private Camera mainCam;
    int mouseClick;
    [SerializeField]
    int range;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStateManager.Instance.gameState==GameState.Playing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                mouseClick = 1;
            }
            if (Input.GetMouseButtonDown(1))
            {
                mouseClick = 2;
            }
            if (mouseClick != 0)
            {
                Click();
            }
        }
    }

    public void Click()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //if (Physics.Raycast(ray, out hit, range, 1<<3))
        //{
        //    goto Skip;
        //}

        if (Physics.Raycast(ray, out hit, range, snowLayer))
        {
            if (mouseClick == 1)
            {
                hit.collider.GetComponent<Block>().Break();
            }
            if (mouseClick == 2 && IceManager.Instance.Ice > 0)
            {
                Block.Build(hit.collider.transform.position, hit.point);
                print(hit.collider.name);
            }
        }

        //Skip:
        mouseClick = 0;
    }
}