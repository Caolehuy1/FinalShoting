using Eflatun.SceneReference;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Shmup {
    public class GameManager : MonoBehaviour {
        [SerializeField] SceneReference mainMenuScene;
        [SerializeField] GameObject gameOverUI;
        [SerializeField] GameObject gameWinUI;
        [SerializeField] Button NextLevel;
        [SerializeField] SceneReference startingLevel;

        public static GameManager Instance { get; private set; }
        public Player Player => player;

        Player player;
        Boss boss;
        int score;
        float restartTimer = 3f;

        public bool IsGameOver() => player.GetHealthNormalized() <= 0 || player.GetFuelNormalized() <= 0;
        public bool IsGameWIn() => player.GetHealthNormalized() >= 0 && boss.GetHealthNormalized() <= 0;

        
        // TODO Add a next level instead of game over when boss dies

        void Awake() {
            Instance = this;
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
            NextLevel.onClick.AddListener(() => Loader.Load(startingLevel));
        }

        void Update() {
            if (IsGameOver()) {
                restartTimer -= Time.deltaTime;

                if (gameOverUI.activeSelf == false) {
                    gameOverUI.SetActive(true);
                }
                    
                if (restartTimer <= 0) {
                    Loader.Load(mainMenuScene);
                }
                
            }
            else
            {
                if (IsGameWIn())
                {
                    gameWinUI.SetActive(true);
                }
            }
        }
        
        public void AddScore(int amount) => score += amount;
        public int GetScore() => score;
    }
}