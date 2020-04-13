using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class SpawnSignSystem : IEcsRunSystem
    {
        private EcsFilter<Cross, Cell>.Exclude<Sign> _filter;
        private EcsFilter<Ring, Cell>.Exclude<Sign> _filter2;
        private Configuration _configuration;

        public void Run()
        {
            foreach (var index in _filter)
            {
                var ecsEntity = _filter.GetEntity(index);
                ecsEntity.Set<Sign>().view = Object.Instantiate(_configuration.Cross, _filter.Get2(index).view.transform, false);
            }

            foreach (var index in _filter2)
            {
                var entity = _filter2.GetEntity(index);
                entity.Set<Sign>().view = Object.Instantiate(_configuration.Ring, _filter2.Get2(index).view.transform, false);
            }
        }
    }
}