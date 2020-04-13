using System;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

namespace TicToe
{
    [Serializable]
    public class GameState
    {
        public bool IsCrossTurn;
        public readonly Dictionary<Vector2Int, EcsEntity> Cells = new Dictionary<Vector2Int, EcsEntity>();
    }
}