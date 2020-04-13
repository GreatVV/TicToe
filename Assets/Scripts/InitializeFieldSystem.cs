using Leopotam.Ecs;
using UnityEngine;

namespace TicToe
{
    internal class InitializeFieldSystem : IEcsInitSystem
    {
        private Configuration _configuration;
        private EcsWorld _world;
        private GameState _gameState;

        public void Init()
        {
            for (int x = 0; x < _configuration.LevelWidth; x++)
            {
                for (int y = 0; y < _configuration.LevelHeight; y++)
                {
                    var cellEntity = _world.NewEntity();
                    cellEntity.Set<Cell>();
                    var position = new Vector2Int(x,y);
                    cellEntity.Set<Position>().value = position;

                    _gameState.Cells[position] = cellEntity;
                }
            }

            _world.NewEntity().Set<UpdateCameraEvent>();
        }
    }
}