using UnityEngine;
using UnityEngine.SceneManagement;

public class backtomenubutton : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
