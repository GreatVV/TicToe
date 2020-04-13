using UnityEngine.SceneManagement;

namespace TicToe
{
    public class LoseScreen : Screen
    {
        public void OnRestartClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}