using Leopotam.Ecs;

namespace Client
{
    internal class MakeAMoveSystem : IEcsRunSystem
    {
        private EcsFilter<Cell, Clicked, Position>.Exclude<Cross, Ring> _filter;
        private GameState _gameState;
        private EcsWorld _world;
        private SceneData _sceneData;

        public void Run()
        {
            foreach (var index in _filter)
            {
                if (_gameState.IsCross)
                {
                    _filter.GetEntity(index).Set<Cross>();
                }
                else
                {
                    _filter.GetEntity(index).Set<Ring>();
                }

                _gameState.IsCross = !_gameState.IsCross;

                _sceneData.UI.GameHUD.TurnOrder.text = _gameState.IsCross ? "Ходят крестики" : "Ходят нолики";

                _filter.GetEntity(index).Set<CheckWin>();
            }
        }
    }
}