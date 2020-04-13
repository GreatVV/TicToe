using Leopotam.Ecs;

namespace Client
{
    internal class ShowWinSystem : IEcsRunSystem
    {
        private EcsFilter<Win> _filter;
        private SceneData _sceneData;
        
        public void Run()
        {
            if (!_filter.IsEmpty())
            {
                foreach (var index in _filter)
                {
                    var winScreen = _sceneData.UI.WinScreen;
                    winScreen.Show(true);
                    if (_filter.Get1(index).IsCross)
                    {
                        winScreen.WinText.text = "Крестики победили";
                    }
                    else
                    {
                        winScreen.WinText.text = "Нолики победили";
                    }
                    _filter.GetEntity(index).Destroy();
                }
            }
        }
    }
}