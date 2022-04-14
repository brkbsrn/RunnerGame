using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerInput PlayerInput;
    public AiInput[] AiInputs;
    public MeshColors MeshColors;
    public PlayerCollision[] PlayerCollisions;
    public GameObject RestartButton;

    private void Awake()
    {
        Instance = this;
    }

    public void GameStart()
    {
        PlayerInput.GameStart();
        for (int i = 0; i < AiInputs.Length; i++)
        {
            AiInputs[i].GameStart();
        }
        MeshColors.enabled = false;
        for (int i = 0; i < PlayerCollisions.Length; i++)
        {
            PlayerCollisions[i].GameStart();
        }
        RestartButton.SetActive(false);
        MeshColors.ResetColors();
    }

    public void GameFinish()
    {
        PlayerInput.GameFinish();
        for (int i = 0; i < AiInputs.Length; i++)
        {
            AiInputs[i].GameFinish();
        }
        MeshColors.enabled = true;
        RestartButton.SetActive(true);
    }
}
