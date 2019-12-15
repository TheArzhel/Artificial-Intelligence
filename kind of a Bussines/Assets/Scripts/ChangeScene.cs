using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update


    public Animator animator; 
    private int levelToLoad;


    

    public void LoadGameScene()
    {
        SceneManager.LoadScene("KindOfaBussines");
    }



    public void FadeToNextLevel()
    {

        FadeTolevel(SceneManager.GetActiveScene().buildIndex+1);

     }

    public void FadeTolevel(int index)
    {

        levelToLoad = index;
        animator.SetTrigger("FadeOut");
        
    }
    public void OnFadeComplete()
    { 
        SceneManager.LoadScene(levelToLoad);

    }

}
