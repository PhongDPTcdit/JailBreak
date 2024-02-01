using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyCode
{
    public class UIFunction : MonoBehaviour
    {
        public void ReLoadSceneFunction(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        public void QuitApp()
        {
            //Application.Quit();
        }
    }
}
