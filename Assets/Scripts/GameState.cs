using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class GameState
    {
        public bool IsCross;
        public Dictionary<Vector2Int, EcsEntity> Cells = new Dictionary<Vector2Int, EcsEntity>();
    }
}