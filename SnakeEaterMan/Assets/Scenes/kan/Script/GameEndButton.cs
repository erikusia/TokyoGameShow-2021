using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndButton : MonoBehaviour
{
    public void OnClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }
}
