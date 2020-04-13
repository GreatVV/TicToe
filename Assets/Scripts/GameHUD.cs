using System;
using UnityEngine;
using UnityEngine.UI;

namespace TicToe
{
    public class GameHUD : MonoBehaviour
    {
        public Text TurnLabel;
        
        public void SetTurn(SignType gameStateCurrentType)
        {
            switch (gameStateCurrentType)
            {
                case SignType.Cross:
                    TurnLabel.text = "Ходит крестик";
                    break;
                case SignType.Ring:
                    TurnLabel.text = "Ходит нолик";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameStateCurrentType), gameStateCurrentType, null);
            }
        }
    }
}