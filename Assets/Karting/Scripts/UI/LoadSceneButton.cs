using UnityEngine;
using UnityEngine.SceneManagement;

namespace KartGame.UI
{
    public class LoadSceneButton : MonoBehaviour
    {
        [Tooltip("What is the name of the scene we want to load when clicking the button?")]
        public string SceneName;
        [Tooltip("What is the name of the trash that will give nitro?")]
        public string levelCollider;


        public void LoadTargetScene() 
        {
            SceneManager.LoadSceneAsync(SceneName);
            NitroCollider.nitroCollider = levelCollider;
        }
    }
}
