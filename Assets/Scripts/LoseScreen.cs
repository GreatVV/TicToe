using UnityEngine;
using UnityEngine.SceneManagement;

namespace Client
{
    public class LoseScreen : MonoBehaviour
    {
        public void OnClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Show(bool state)
        {
            gameObject.SetActive(state);
        }
    }
}