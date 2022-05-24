using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneScript : MonoBehaviour
{
    public void SceneChange(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }
}
