using Leopotam.Ecs;
using UnityEngine;

namespace TicToe
{
    internal class InitFieldSystem : IEcsInitSystem
    {
        private SceneData _sceneData;
        private EcsWorld _world;
        private GameState _gameState;

        public void Init()
        {
            for (int x = 0; x < _sceneData.Width; x++)
            {
                for (int y = 0; y < _sceneData.Height; y++)
                {
                    var cell = _world.NewEntity();
                    cell.Set<Cell>();
                    var position = new Vector2Int(x,y);
                    cell.Set<Position>().value = position;
                    _gameState.Cells[position] = cell;
                }
            }
            
            _sceneData.Camera.transform.position = new Vector3((_sceneData.Width + (_sceneData.Width - 1) * _sceneData.Offset.x)/2f, (_sceneData.Height + (_sceneData.Height - 1) * _sceneData.Offset.y)/2f);
            _sceneData.Camera.orthographicSize = (_sceneData.Height + (_sceneData.Height - 1) * _sceneData.Offset.y)/2f;
        }
    }
}