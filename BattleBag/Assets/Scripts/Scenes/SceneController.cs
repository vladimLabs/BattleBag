using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public class SceneController : MonoBehaviour
    {
        public void LoadSceneFihgt()
        {
            SceneManager.LoadScene("Fight");
        }
        public void LloadSceneShop()
        {
            SceneManager.LoadScene("BagShop");
        }
    }
}