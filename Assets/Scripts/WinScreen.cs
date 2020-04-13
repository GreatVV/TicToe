using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TicToe
{
    public class WinScreen : MonoBehaviour
    {
        public Text WinnerText;

        public void Show(bool state)
        {
            gameObject.SetActive(state);
        }

        public void OnClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}