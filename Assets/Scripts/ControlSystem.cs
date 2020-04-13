using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    internal class ControlSystem : IEcsRunSystem
    {
        private SceneData _sceneData;
        
        public void Run()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = _sceneData.Camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hitInfo))
                {
                    var cellView = hitInfo.collider.gameObject.GetComponent<CellView>();
                    if (cellView)
                    {
                        cellView.Entity.Set<Clicked>();
                    }
                }
            }
        }
    }
}