using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using NUnit.Framework;
using TicToe;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    [TestFixture]
    public class GameLogicTests
    {
        [Test]
        public void CheckHorizontalChainZero()
        {
            var world = new EcsWorld();

            Dictionary<Vector2Int, EcsEntity> cells = new Dictionary<Vector2Int, EcsEntity>()
            {
                {new Vector2Int(0, 0), CreateCell(world,new Vector2Int(0,0))}, 
                {new Vector2Int(0, 1), CreateCell(world,new Vector2Int(0,1))}, 
                {new Vector2Int(0, 2), CreateCell(world,new Vector2Int(0,2))}, 
                {new Vector2Int(1, 0), CreateCell(world,new Vector2Int(1,0))}, 
                {new Vector2Int(1, 1), CreateCell(world,new Vector2Int(1,1))}, 
                {new Vector2Int(1, 2), CreateCell(world,new Vector2Int(1,2))},
                {new Vector2Int(2, 0), CreateCell(world,new Vector2Int(2,0))}, 
                {new Vector2Int(2, 1), CreateCell(world,new Vector2Int(2,1))}, 
                {new Vector2Int(2, 2), CreateCell(world,new Vector2Int(2,2))},
            };

            var chainLength = GameExtensions.GetLongestChain(cells, Vector2Int.zero);
            
            Assert.AreEqual(0, chainLength);
        }
        
        [Test]
        public void CheckHorizontalChainOne()
        {
            var world = new EcsWorld();

            Dictionary<Vector2Int, EcsEntity> cells = new Dictionary<Vector2Int, EcsEntity>()
            {
                {new Vector2Int(0, 0), CreateCell(world,new Vector2Int(0,0))}, 
                {new Vector2Int(0, 1), CreateCell(world,new Vector2Int(0,1))}, 
                {new Vector2Int(0, 2), CreateCell(world,new Vector2Int(0,2))}, 
                {new Vector2Int(1, 0), CreateCell(world,new Vector2Int(1,0))}, 
                {new Vector2Int(1, 1), CreateCell(world,new Vector2Int(1,1))}, 
                {new Vector2Int(1, 2), CreateCell(world,new Vector2Int(1,2))},
                {new Vector2Int(2, 0), CreateCell(world,new Vector2Int(2,0))}, 
                {new Vector2Int(2, 1), CreateCell(world,new Vector2Int(2,1))}, 
                {new Vector2Int(2, 2), CreateCell(world,new Vector2Int(2,2))},
            };

            cells[Vector2Int.zero].Set<Taken>().value = SignType.Cross;

            var chainLength = cells.GetLongestChain(Vector2Int.zero);
            
            Assert.AreEqual(1, chainLength);
        }
        
        [Test]
        public void CheckHorizontalChainTwoLeft()
        {
            var world = new EcsWorld();

            Dictionary<Vector2Int, EcsEntity> cells = new Dictionary<Vector2Int, EcsEntity>()
            {
                {new Vector2Int(0, 0), CreateCell(world,new Vector2Int(0,0))}, 
                {new Vector2Int(0, 1), CreateCell(world,new Vector2Int(0,1))}, 
                {new Vector2Int(0, 2), CreateCell(world,new Vector2Int(0,2))}, 
                {new Vector2Int(1, 0), CreateCell(world,new Vector2Int(1,0))}, 
                {new Vector2Int(1, 1), CreateCell(world,new Vector2Int(1,1))}, 
                {new Vector2Int(1, 2), CreateCell(world,new Vector2Int(1,2))},
                {new Vector2Int(2, 0), CreateCell(world,new Vector2Int(2,0))}, 
                {new Vector2Int(2, 1), CreateCell(world,new Vector2Int(2,1))}, 
                {new Vector2Int(2, 2), CreateCell(world,new Vector2Int(2,2))},
            };

            cells[new Vector2Int(2, 0)].Set<Taken>().value = SignType.Cross;
            cells[new Vector2Int(1, 0)].Set<Taken>().value = SignType.Cross;

            var chainLength = cells.GetLongestChain(new Vector2Int(2, 0));
            
            Assert.AreEqual(2, chainLength);
        }
        
        [Test]
        public void CheckHorizontalChainTwoRight()
        {
            var world = new EcsWorld();

            Dictionary<Vector2Int, EcsEntity> cells = new Dictionary<Vector2Int, EcsEntity>()
            {
                {new Vector2Int(0, 0), CreateCell(world,new Vector2Int(0,0))}, 
                {new Vector2Int(0, 1), CreateCell(world,new Vector2Int(0,1))}, 
                {new Vector2Int(0, 2), CreateCell(world,new Vector2Int(0,2))}, 
                {new Vector2Int(1, 0), CreateCell(world,new Vector2Int(1,0))}, 
                {new Vector2Int(1, 1), CreateCell(world,new Vector2Int(1,1))}, 
                {new Vector2Int(1, 2), CreateCell(world,new Vector2Int(1,2))},
                {new Vector2Int(2, 0), CreateCell(world,new Vector2Int(2,0))}, 
                {new Vector2Int(2, 1), CreateCell(world,new Vector2Int(2,1))}, 
                {new Vector2Int(2, 2), CreateCell(world,new Vector2Int(2,2))},
            };

            cells[new Vector2Int(2, 0)].Set<Taken>().value = SignType.Cross;
            cells[new Vector2Int(1, 0)].Set<Taken>().value = SignType.Cross;

            var chainLength = cells.GetLongestChain(new Vector2Int(1, 0));
            
            Assert.AreEqual(2, chainLength);
        }
        
        [Test]
        public void CheckChainTwoVertical()
        {
            var world = new EcsWorld();

            Dictionary<Vector2Int, EcsEntity> cells = new Dictionary<Vector2Int, EcsEntity>()
            {
                {new Vector2Int(0, 0), CreateCell(world,new Vector2Int(0,0))}, 
                {new Vector2Int(0, 1), CreateCell(world,new Vector2Int(0,1))}, 
                {new Vector2Int(0, 2), CreateCell(world,new Vector2Int(0,2))}, 
                {new Vector2Int(1, 0), CreateCell(world,new Vector2Int(1,0))}, 
                {new Vector2Int(1, 1), CreateCell(world,new Vector2Int(1,1))}, 
                {new Vector2Int(1, 2), CreateCell(world,new Vector2Int(1,2))},
                {new Vector2Int(2, 0), CreateCell(world,new Vector2Int(2,0))}, 
                {new Vector2Int(2, 1), CreateCell(world,new Vector2Int(2,1))}, 
                {new Vector2Int(2, 2), CreateCell(world,new Vector2Int(2,2))},
            };

            cells[new Vector2Int(0, 0)].Set<Taken>().value = SignType.Cross;
            cells[new Vector2Int(0, 1)].Set<Taken>().value = SignType.Cross;

            var chainLength = cells.GetLongestChain(new Vector2Int(0, 0));
            
            Assert.AreEqual(2, chainLength);
        }
        
        [Test]
        public void CheckChainThreeVertical()
        {
            var world = new EcsWorld();

            Dictionary<Vector2Int, EcsEntity> cells = new Dictionary<Vector2Int, EcsEntity>()
            {
                {new Vector2Int(0, 0), CreateCell(world,new Vector2Int(0,0))}, 
                {new Vector2Int(0, 1), CreateCell(world,new Vector2Int(0,1))}, 
                {new Vector2Int(0, 2), CreateCell(world,new Vector2Int(0,2))}, 
                {new Vector2Int(1, 0), CreateCell(world,new Vector2Int(1,0))}, 
                {new Vector2Int(1, 1), CreateCell(world,new Vector2Int(1,1))}, 
                {new Vector2Int(1, 2), CreateCell(world,new Vector2Int(1,2))},
                {new Vector2Int(2, 0), CreateCell(world,new Vector2Int(2,0))}, 
                {new Vector2Int(2, 1), CreateCell(world,new Vector2Int(2,1))}, 
                {new Vector2Int(2, 2), CreateCell(world,new Vector2Int(2,2))},
            };

            cells[new Vector2Int(0, 0)].Set<Taken>().value = SignType.Cross;
            cells[new Vector2Int(0, 1)].Set<Taken>().value = SignType.Cross;
            cells[new Vector2Int(0, 2)].Set<Taken>().value = SignType.Cross;

            var chainLength = cells.GetLongestChain(new Vector2Int(0, 1));
            
            Assert.AreEqual(3, chainLength);
        }
        
        [Test]
        public void CheckChainThreeDiagonalOne()
        {
            var world = new EcsWorld();

            Dictionary<Vector2Int, EcsEntity> cells = new Dictionary<Vector2Int, EcsEntity>()
            {
                {new Vector2Int(0, 0), CreateCell(world,new Vector2Int(0,0))}, 
                {new Vector2Int(0, 1), CreateCell(world,new Vector2Int(0,1))}, 
                {new Vector2Int(0, 2), CreateCell(world,new Vector2Int(0,2))}, 
                {new Vector2Int(1, 0), CreateCell(world,new Vector2Int(1,0))}, 
                {new Vector2Int(1, 1), CreateCell(world,new Vector2Int(1,1))}, 
                {new Vector2Int(1, 2), CreateCell(world,new Vector2Int(1,2))},
                {new Vector2Int(2, 0), CreateCell(world,new Vector2Int(2,0))}, 
                {new Vector2Int(2, 1), CreateCell(world,new Vector2Int(2,1))}, 
                {new Vector2Int(2, 2), CreateCell(world,new Vector2Int(2,2))},
            };

            cells[new Vector2Int(0, 0)].Set<Taken>().value = SignType.Cross;
            cells[new Vector2Int(1, 1)].Set<Taken>().value = SignType.Cross;
            cells[new Vector2Int(2, 2)].Set<Taken>().value = SignType.Cross;

            var chainLength = cells.GetLongestChain(new Vector2Int(1, 1));
            
            Assert.AreEqual(3, chainLength);
        }
        
        [Test]
        public void CheckChainThreeDiagonalOther()
        {
            var world = new EcsWorld();

            Dictionary<Vector2Int, EcsEntity> cells = new Dictionary<Vector2Int, EcsEntity>()
            {
                {new Vector2Int(0, 0), CreateCell(world,new Vector2Int(0,0))}, 
                {new Vector2Int(0, 1), CreateCell(world,new Vector2Int(0,1))}, 
                {new Vector2Int(0, 2), CreateCell(world,new Vector2Int(0,2))}, 
                {new Vector2Int(1, 0), CreateCell(world,new Vector2Int(1,0))}, 
                {new Vector2Int(1, 1), CreateCell(world,new Vector2Int(1,1))}, 
                {new Vector2Int(1, 2), CreateCell(world,new Vector2Int(1,2))},
                {new Vector2Int(2, 0), CreateCell(world,new Vector2Int(2,0))}, 
                {new Vector2Int(2, 1), CreateCell(world,new Vector2Int(2,1))}, 
                {new Vector2Int(2, 2), CreateCell(world,new Vector2Int(2,2))},
            };

            cells[new Vector2Int(0, 2)].Set<Taken>().value = SignType.Cross;
            cells[new Vector2Int(1, 1)].Set<Taken>().value = SignType.Cross;
            cells[new Vector2Int(2, 0)].Set<Taken>().value = SignType.Cross;

            var chainLength = cells.GetLongestChain(new Vector2Int(1, 1));
            
            Assert.AreEqual(3, chainLength);
        }

        private static EcsEntity CreateCell(EcsWorld world, Vector2Int position)
        {
            var entity = world.NewEntity();
            entity.Set<Position>().value = position;
            entity.Set<Cell>();

            return entity;
        }
    }
}
