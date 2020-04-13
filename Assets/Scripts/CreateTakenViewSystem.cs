using System;
using Leopotam.Ecs;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TicToe
{
    public class CreateTakenViewSystem : IEcsRunSystem
    {
        private EcsFilter<Taken, CellViewRef>.Exclude<TakenRef> _filter;
        private Configuration _configuration;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                var position = _filter.Get2(index).value.transform.position;
                var takenType = _filter.Get1(index).value;

                SignView signView = null;
                switch (takenType)
                {
                    case SignType.Cross:
                        signView = _configuration.CrossView;
                        break;
                    case SignType.Ring:
                        signView = _configuration.RingView;
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                var instance = Object.Instantiate(signView, position, Quaternion.identity);
                _filter.GetEntity(index).Set<TakenRef>().value = instance;
            }
        }
    }
}