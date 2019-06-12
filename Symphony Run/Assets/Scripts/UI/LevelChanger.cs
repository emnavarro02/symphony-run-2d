/**
 * The main idea of this script came from here: https://www.youtube.com/watch?v=Oadq-IrOazg
 */
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private int levelToLoad;

    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete ()
    {
        print("LevelChanger: "+levelToLoad);
        SceneManager.LoadScene(levelToLoad);
    }
}
