using System;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.XR.WSA;

namespace Client
{
    sealed class EcsStartup : MonoBehaviour
    {
        EcsWorld _world;
        EcsSystems _systems;

        public SceneData SceneData;
        public Configuration Configuration;

        void Start()
        {
            // void can be switched to IEnumerator for support coroutines.

            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
            _systems
                // register your systems here, for example:
                .Add(new InitializeFieldSystem())
                .Add(new ControlSystem())
                .Add(new MakeAMoveSystem())
                .Add(new SpawnSignSystem())
                .Add(new CheckWinSystem())
                .Add(new ShowWinSystem())
                .Add(new CheckLoseSystem())

                // register one-frame components (order is important), for example:
                .OneFrame<Clicked>()
                // .OneFrame<TestComponent2> ()

                // inject service instances here (order doesn't important), for example:
                .Inject(new GameState())
                .Inject(SceneData)
                .Inject(Configuration)
                .Init();
        }

        void Update()
        {
            _systems?.Run();
        }

        void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }
    }
}