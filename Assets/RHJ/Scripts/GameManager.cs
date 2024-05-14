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
        CHECKFIRE
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
                //���� ���൵�� ���� �б����̵Ǵ� ����� �ݶ��̴� Ȱ��ȭ
                case GameState.GO7F:
                    goals[0].SetActive(true);
                    break;

                case GameState.CHECKFIRE:
                    goals[1].SetActive(true);
                    break;
            }
        }
    }


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
