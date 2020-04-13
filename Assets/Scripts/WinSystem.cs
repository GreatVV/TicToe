using Leopotam.Ecs;

namespace TicToe
{
    internal class WinSystem : IEcsRunSystem
    {
        private EcsFilter<Win> _wins;
        private SceneData _sceneData;
        
        public void Run()
        {
            if (!_wins.IsEmpty())
            {
                foreach (var index in _wins)
                {
                    var winner = _wins.Get1(index).IsCross;

                    _sceneData.UI.WinScreen.WinnerText.text = winner ? "Крестик" : "Нолик";
                    _sceneData.UI.WinScreen.Show(true);
                }
            }
        }
    }
}