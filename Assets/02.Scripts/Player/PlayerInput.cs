using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
 
    public PlayerInputActions InputActions { get; private set; }
    public PlayerInputActions.PlayerActions PlayerActions { get; private set; }
    public PlayerInputActions.TycoonPlayerActions TycoonPlayerActions { get; private set; }

    private void Awake()
    {
        InputActions = new PlayerInputActions();
        //PlayerActions = InputActions.Player;

         SceneManager.sceneLoaded += LoadedsceneEvent;

        //InIt();
    }

    private void LoadedsceneEvent(Scene scene, LoadSceneMode mode)
    {

        InputActions.Dispose();

        if (scene.name == "LodingScene")
        {
            return;
        }

        InputActions = new PlayerInputActions();

        if (scene.name == "KGM_TestVillage")
        {
            TycoonPlayerActions = InputActions.TycoonPlayer;
        }
        else
        {
            PlayerActions = InputActions.Player;
        }
    }


    private void InIt()
    {
        if (SceneManager.GetActiveScene().name == "LoadingScene") return;

        if (SceneManager.GetActiveScene().name == "KGM_TestVillage")
        {
            TycoonPlayerActions = InputActions.TycoonPlayer;
        }
        else
        {
            PlayerActions = InputActions.Player;
        }

    }


    private void OnEnable()
    {
        InputActions.Enable();
    }

    private void OnDisable()
    {
        InputActions.Disable();
    }

}
