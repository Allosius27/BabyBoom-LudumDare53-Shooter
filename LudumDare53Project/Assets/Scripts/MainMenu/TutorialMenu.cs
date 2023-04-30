using AllosiusDevCore;
using AllosiusDevUtilities.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMenu : MonoBehaviour
{
    #region Fields

    #endregion

    #region Properties

    #endregion

    #region Events

    #endregion

    #region UnityInspector

    [SerializeField] private AudioData _musicData;

    [SerializeField] private SceneData _startGameScene;

    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    #endregion

    #region Class

    #endregion

    #region Behaviour

    private void Start()
    {
        Cursor.SetCursor(null, hotSpot, cursorMode);

        AudioController.Instance.PlayAudio(_musicData);

        PauseMenu.canPause = false;
    }

    public void PlayLevel()
    {
        GameManager.Instance.firstParty = false;
        PauseMenu.canPause = true;
        SceneLoader.Instance.ChangeScene(_startGameScene.sceneToLoad);
    }

    public void MainMenuButton()
    {
        SceneLoader.Instance.ChangeScene(Scenes.MainMenu);
    }

    #endregion

    #region Gizmos

    #endregion
}
