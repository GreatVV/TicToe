using UnityEngine;

namespace TicToe
{
    public class SceneData : MonoBehaviour
    {
        public int Width;
        public int Height;

        public Vector2 Offset;
        public Camera Camera;

        public CellView Cell;
        public TakenView Ring;
        public TakenView Cross;

        public UI UI;
    }
}