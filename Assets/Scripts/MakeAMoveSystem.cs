using Leopotam.Ecs;

namespace TicToe
{
    public class MakeAMoveSystem : IEcsRunSystem
    {
        private EcsFilter<Cell, Clicked>.Exclude<Taken> _filter;
        private GameState _gameState;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                if (_gameState.IsCrossTurn)
                {
                    _filter.GetEntity(index).Set<Taken>().isCross = true;
                }
                else
                {
                    _filter.GetEntity(index).Set<Taken>().isCross = false;
                }

                _gameState.IsCrossTurn = !_gameState.IsCrossTurn;

                _filter.GetEntity(index).Set<CheckWin>();
            }
        }
    }
}