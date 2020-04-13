using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TicToe
{
    public class WinScreen : Screen
    {
        public Text Text;
        
        public void SetWinner(SignType value)
        {
            switch (value)
            {
                case SignType.Cross:
                    Text.text = "Крестик победил";
                    break;
                case SignType.Ring:
                    Text.text = "Нолик победил";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        public void OnRestartClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}