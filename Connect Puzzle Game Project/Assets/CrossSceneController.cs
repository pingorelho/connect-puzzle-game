using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class CrossSceneController
{
    public static int CurrentLevel { get; set; }
    public static string CurrentWorld { get; set; }

    public static bool BackFromLevel { get; set; }
}
