using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class CrossSceneController
{
    //These props are used globally to help with transitionings between scenes
    public static int CurrentLevel { get; set; }
    public static string CurrentWorld { get; set; }

    public static bool BackFromLevel { get; set; }
}
