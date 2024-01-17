using System.Collections.Generic;
using Collapse.Blocks;
using UnityEngine;
using DG.Tweening;

namespace Collapse {
    /**
     * Partial class for separating the main functions that are needed to be modified in the context of this test
     */
    public partial class BoardManager
    {
        [SerializeField] private float tiggerFadeTime = 0.1f;
        private Sequence bombSequence;
        /**
         * Trigger a bomb
         */
        public void TriggerBomb(Bomb bomb) {
            //TODO: Implement
        }

        /**
         * Trigger a match
         */
        public void TriggerMatch(Block block) {
            // Find all blocks in this match
            var results = new List<Block>();
            var tested = new List<(int row, int col)>();
            FindChainRecursive(block.Type, block.GridPosition.x, block.GridPosition.y, ref tested, ref results);
            
            // Trigger blocks
            int highestDelay = results.Count;
            for (var i = 0; i < results.Count; i++) {
                results[i].Triger(i*tiggerFadeTime);
            }

            // Regenerate
            ScheduleRegenerateBoard(highestDelay*tiggerFadeTime);
        }


        /**
         * Recursively collect all neighbors of same type to build a full list of blocks in this "chain" in the results list
         */
        private void FindChainRecursive(BlockType type, int col, int row, ref List<(int row, int col)> testedPositions,
            ref List<Block> results)
        {
            //TODO: Replace this with real implementation
            if (testedPositions.Contains((row, col))) return;
            testedPositions.Add((row, col));

            Block b = GetBlockOnGrid(col, row);

            if (b == null || b.Type != type) return;
            results.Add(b);
          
            FindChainRecursive(type, col + 1, row, ref testedPositions, ref results);
            FindChainRecursive(type, col - 1, row, ref testedPositions, ref results);
            FindChainRecursive(type, col, row + 1, ref testedPositions, ref results);
            FindChainRecursive(type, col, row - 1, ref testedPositions, ref results);
        }
    }
}