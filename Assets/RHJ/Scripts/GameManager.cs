using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> goals;

    public enum GameState
    {
        NONE,
        GO7F,
        CHECKFIRE,
        CHECKNPC
    }
    public GameState nowState = GameState.NONE;
    public GameState nextState = GameState.NONE;

    void Update()
    {
        if (nowState != nextState)
        {
            nowState = nextState;
            switch (nowState)
            {
                //게임 진행도에 따라 분기점이되는 장소의 콜라이더 활성화
                case GameState.GO7F:
                    goals[0].SetActive(true);
                    break;

                case GameState.CHECKFIRE:
                    goals[1].SetActive(true);
                    break;

                case GameState.CHECKNPC:
                    // npc의 존재를 알아채는 collider. 7F에 존재
                    goals[2].SetActive(true);
                    // npc quest 싱글톤 생성
                    NPCquestManager.Instance.nextProcess = 0;
                    break;

            }
        }
    }


    // Non-Lazy Non-DDOL Singleton

    private static GameManager _Instance;
    public static GameManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindAnyObjectByType<GameManager>();
            }
            return _Instance;
        }
    }
}
