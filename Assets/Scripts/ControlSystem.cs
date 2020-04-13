using Leopotam.Ecs;
using UnityEngine;

namespace TicToe
{
    public class ControlSystem : IEcsRunSystem
    {
        private SceneData _sceneData;
        
        public void Run()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = _sceneData.Camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hitInfo))
                {
                    var cellView = hitInfo.collider.GetComponent<CellView>();
                    if (cellView)
                    {
                        cellView.value.Set<Clicked>();
                    }
                }
            }
        }
    }
}