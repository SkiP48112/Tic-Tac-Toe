using Code.Logic.Contracts;
using UnityEngine.SceneManagement;

namespace Code.Logic
{
    public class SceneLoader : ISceneLoader
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadSceneAsync(sceneName);
        }
    }
}