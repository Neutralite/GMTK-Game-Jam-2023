using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField]
    CharacterController controller;
    float x, z;
    [SerializeField]
    float speed=1f;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    void Update()
    {
        if (/*GameStateManager.Instance.gameState== GameState.Playing*/true)
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z + Vector3.down;

            controller.Move(move * speed * Time.deltaTime);
        }
    }
}
