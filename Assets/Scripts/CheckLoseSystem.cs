using Leopotam.Ecs;

namespace Client
{
    public class CheckLoseSystem : IEcsRunSystem
    {
        private EcsFilter<Cross> _crosses;
        private EcsFilter<Ring> _rings;
        private SceneData _sceneData;

        public void Run()
        {
            if (_crosses.GetEntitiesCount() + _rings.GetEntitiesCount() == _sceneData.Width * _sceneData.Height)
            {
                _sceneData.UI.LoseScreen.Show(true);
            }
        }
    }
}