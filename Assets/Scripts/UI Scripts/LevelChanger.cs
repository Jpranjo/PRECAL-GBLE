using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string levelToLoad;


    public void FadeToLevel(string sceneName){
        animator.SetTrigger("FadeOut");
        levelToLoad = sceneName;
    }

    public void OnFadeComplete(){
        SceneManager.LoadScene(levelToLoad);
    }
}
