using System.Collections.Generic;
using Collapse.Blocks;

namespace Collapse {
    /**
     * Partial class for convenience in the context of  this test - the BoardManager functions that need to be touched are in this file
     */
    public partial class BoardManager {
        public void TriggerBomb(Bomb bomb) {
            //TODO: Implement
        }

        /**
         * Trigger a match
         */
        public void TriggerMatch(Block block) {
            var results = new List<Block>();
            var tested = new List<(int row, int col)>();
            FindChainRecursive(block.Type, block.GridPosition.x, block.GridPosition.y, tested, results);
            for (var i = 0; i < results.Count; i++) {
                var result = results[i];
                MatchBlock(result, i);
            }

            ScheduleRegenerateBoard();
        }

        private void MatchBlock(Block block, int index) {
            ClearBlockFromGrid(block);

            // Trigger block match animation
            block.Triger(index);
        }

        /**
         * Recursively collect all neighbors of same type to build a full list of blocks in this "chain" in the results list
         */
        private void FindChainRecursive(BlockType type, int col, int row, List<(int row, int col)> testedPositions,
            List<Block> results) {
            //TODO: Replace this with real implementation
            results.Add(blocks[col, row]);
        }
    }
}