using Leopotam.Ecs;
using UnityEngine;

namespace TicToe
{
    internal class CreateCellViewSystem : IEcsRunSystem
    {
        private EcsFilter<Cell, Position>.Exclude<CellViewRef> _filter;
        private SceneData _sceneData;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var position = ref _filter.Get2(index).value;
                var cellView = Object.Instantiate(_sceneData.Cell);
                cellView.transform.position = new Vector3(position.x + position.x * _sceneData.Offset.x, position.y + position.y * _sceneData.Offset.y)+ Vector3.one / 2f;
                cellView.value = _filter.GetEntity(index);
                _filter.GetEntity(index).Set<CellViewRef>().value = cellView;
            }
        }
    }
}