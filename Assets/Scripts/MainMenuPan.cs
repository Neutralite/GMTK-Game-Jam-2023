using UnityEngine;

public class MainMenuPan : MonoBehaviour
{
    bool playing;
    // Update is called once per frame
    void Update()
    {
        if (GameStateManager.Instance.gameState == GameState.MainMenu)
        {
            transform.Rotate(0, Time.fixedDeltaTime, 0);
        }
        else if (!playing)
        {
            transform.GetComponentInChildren<CharacterController>().enabled = false;
            transform.GetChild(0).localPosition = Vector3.up * 10;
            transform.GetComponentInChildren<CharacterController>().enabled = true;
            playing = true;
        }
    }
}
