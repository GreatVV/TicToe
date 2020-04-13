using UnityEngine;

namespace Client
{
    [CreateAssetMenu]
    public class Configuration : ScriptableObject
    {
        public CellView Cell;
        public GameObject Cross;
        public GameObject Ring;
    }
}