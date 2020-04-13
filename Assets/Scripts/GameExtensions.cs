using System;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

namespace TicToe
{
    public static class GameExtensions
    {
        public static int GetLongestChain(this Dictionary<Vector2Int, EcsEntity> cells, Vector2Int position)
        {
            var startEntity = cells[position];
            if (!startEntity.Has<Taken>())
            {
                return 0;
            }

            var startType = startEntity.Ref<Taken>().Unref().value;

            var horizontalLength = Count(cells, position, new Vector2Int(1, 0), startType, 1, new Vector2Int(-1, 0));
            var verticalLength = Count(cells, position, new Vector2Int(0, 1), startType, 1, new Vector2Int(0, -1));
            var diagonalOne = Count(cells, position, new Vector2Int(-1, -1), startType, 1, new Vector2Int(1, 1));
            var diagonalOther = Count(cells, position, new Vector2Int(-1, 1), startType, 1, new Vector2Int(1, -1));

            return Mathf.Max(verticalLength, horizontalLength, diagonalOne, diagonalOther);
        }

        private static int Count(Dictionary<Vector2Int, EcsEntity> cells, Vector2Int position, Vector2Int direction, SignType startType,
            int diagonalOne, Vector2Int direction2)
        {
            var currentPosition = position + direction;

            while (cells.TryGetValue(currentPosition, out var entity))
            {
                if (!entity.Has<Taken>())
                {
                    break;
                }
                else
                {
                    var type = entity.Ref<Taken>().Unref().value;
                    if (type != startType)
                    {
                        break;
                    }

                    diagonalOne++;
                    currentPosition += direction;
                }
            }

            currentPosition = position + direction2;
            while (cells.TryGetValue(currentPosition, out var entity))
            {
                if (!entity.Has<Taken>())
                {
                    break;
                }

                var type = entity.Ref<Taken>().Unref().value;
                if (type != startType)
                {
                    break;
                }

                diagonalOne++;
                currentPosition += direction2;
            }

            return diagonalOne;
        }
    }
}