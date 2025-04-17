using UnityEngine;
using UnityEngine.SceneManagement;

public class instructionsbutton : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
