using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class InitializeFieldSystem : IEcsInitSystem
    {
        private SceneData _sceneData;
        private Configuration _configuration;
        private EcsWorld _world;
        private GameState _gameState;
        
        public void Init()
        {
            for (int i = 0; i < _sceneData.Width; i++)
            {
                for (int j = 0; j < _sceneData.Height; j++)
                {
                    var entity = _world.NewEntity();
                    var value = new Vector2Int(i,j);
                    entity.Set<Position>().value = value;
                    var cellView = Object.Instantiate(_configuration.Cell, new Vector3(i,j, 0) + Vector3.one / 2f + new Vector3(i * _sceneData.Offset, j* _sceneData.Offset), Quaternion.identity);
                    entity.Set<Cell>().view = cellView;
                    cellView.Entity = entity;

                    _gameState.Cells[value] = entity;
                }
            }

            _sceneData.Camera.transform.position = new Vector3((_sceneData.Width + (_sceneData.Width - 1) * _sceneData.Offset)/2f, (_sceneData.Height + (_sceneData.Height - 1) * _sceneData.Offset)/2f);
            _sceneData.Camera.orthographicSize = (_sceneData.Height + (_sceneData.Height - 1) * _sceneData.Offset)/2f;
        }
    }
}