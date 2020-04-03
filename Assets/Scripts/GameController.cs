using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Editor
    [SerializeField]
    private List<Block> enemyBlocks;
    [SerializeField]
    EnemyController enemy;
    [SerializeField]
    UIController uiController;
    #endregion

    private int enemyBlocksOnField;
    private int currentLevel = 1;

    void Awake()
    {
        enemyBlocksOnField = enemyBlocks.Count;
        enemyBlocks.ForEach((block) =>
        {
            block.OnDestroy += OnBlockDestroy;
        });
        Time.timeScale = 1;
    }


    private void OnBlockDestroy()
    {
        enemyBlocksOnField--;
        if(enemyBlocksOnField <= 0)
        {
            PlayerWon();
        }
    }

    private void PlayerWon()
    {
        enemyBlocksOnField = enemyBlocks.Count;

        //respawn blocks
        enemyBlocks.ForEach((block) =>
        {
            block.Init();
        });
        
        enemy.Speed++;

        //update UI
        currentLevel++;
        uiController.CurrentLevel = currentLevel;
    }
}
