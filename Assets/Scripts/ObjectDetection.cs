using UnityEngine;

public class ObjectDetection : MonoBehaviour
{
    // Bit shift the index of the layer to get a bit mask
    int rootLayer = 1 << 6;

    private Camera mainCam;
    int mouseClick;

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

        if (Physics.Raycast(ray, out hit, 15, rootLayer))
        {
            if (mouseClick == 1)
            {
                hit.collider.GetComponent<Block>().Break();
            }
            if (mouseClick == 2 && Block.collected > 0)
            {
                Block.Build(hit.collider.transform.position, hit.point);
            }
        }

        mouseClick = 0;
    }
}