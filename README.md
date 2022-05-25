# Collapse Test Project

This project is a simplistic version of a collpase in Unity (2020.3)
- The board should start popuplated with a grid of blocks.
- Clicking a block should "match" all connected neighboring blocks (up, right, down, left) and destroy them.
- After a short delay the board should be repopulated.
- The game will be tested only inside the unity editor

Please fork this repo and complete the following tasks, send us a link to the repo once you're done.

1. The file *BoardManagerInteractionLogic.cs* contains an unimplemented critical function *FindChainRecursive* - please implement it using recursion.

2. Now that clicking blocks makes whole groups match and disappear correctly we can see that the blocks disappear instantanously and that's not the experience we're after - please improve the visuals of the disappearance of blocks in any way you see fit. (Hint: the project is making heavy use of DOTween)

3. As you can probably tell the Bombs don't really work, please find the *Bomb* class and make them work:
	- Clicking a Bomb should cause it to shake and destroy all blocks around it (in all 9 directions)
	- Bonus points if Bomb explosions are delayed and not happen all at once, in order to create a fun chain effect. Board regeneration should be done only after all Bombs are exploded.
