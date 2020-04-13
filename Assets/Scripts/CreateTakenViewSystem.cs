using Leopotam.Ecs;
using UnityEngine;

namespace TicToe
{
    public class CreateTakenViewSystem : IEcsRunSystem
    {
        private EcsFilter<Taken, CellViewRef>.Exclude<TakenViewRef> _filter;
        private SceneData _sceneData;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                var cellView = _filter.Get2(index).value;
                var taken = _filter.Get1(index).isCross;
                var takenView = Object.Instantiate(taken ? _sceneData.Cross : _sceneData.Ring, cellView.transform, false);
                _filter.GetEntity(index).Set<TakenViewRef>().value = takenView;
            }
        }
    }
}