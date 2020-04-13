using Leopotam.Ecs;
using UnityEngine;

namespace TicToe
{
    internal class SetCameraSystem : IEcsRunSystem
    {
        private EcsFilter<UpdateCameraEvent> _filter;
        private SceneData SceneData;
        private Configuration _configuration;

        public void Run()
        {
            if (!_filter.IsEmpty())
            {
                var height = _configuration.LevelHeight;
                
                var camera = SceneData.Camera;
                camera.orthographic = true;
                camera.orthographicSize = height / 2f + (height - 1) * _configuration.Offset.y / 2;
                
                SceneData.CameraTransform.position = new Vector3(_configuration.LevelWidth / 2f + (_configuration.LevelWidth - 1) * _configuration.Offset.x / 2, height / 2f + (height - 1) * _configuration.Offset.y / 2);
            }
        }
    }
}