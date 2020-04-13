using Leopotam.Ecs;
using UnityEngine.SceneManagement;

namespace TicToe
{
    public class AnalyzeClickSystem : IEcsRunSystem
    {
        private EcsFilter<Cell, Clicked>.Exclude<Taken> _filter;
        private GameState _gameState;
        private SceneData _sceneData;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var ecsEntity = ref _filter.GetEntity(index);
                ecsEntity.Set<Taken>().value = _gameState.CurrentType;
                ecsEntity.Set<CheckWinEvent>();

                _gameState.CurrentType = _gameState.CurrentType == SignType.Cross ? SignType.Ring : SignType.Cross;

                _sceneData.UI.GameHUD.SetTurn(_gameState.CurrentType);
            }
        }
    }
}