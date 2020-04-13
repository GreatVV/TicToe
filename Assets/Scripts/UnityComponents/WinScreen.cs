using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UnityComponents
{
    public class WinScreen : MonoBehaviour
    {
        public Text WinText;

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
