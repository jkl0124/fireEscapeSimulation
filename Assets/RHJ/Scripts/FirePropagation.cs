using UnityEngine;

public class FirePropagation : MonoBehaviour
{
    
    public int gridSize = 10; // 그리드 크기
    public float propagationRate = 0.6f; // 불의 확산 속도
    private int[,] grid; // 불의 상태를 저장하는 그리드 배열
    private SpriteRenderer[,] cellRenderers; // 각 셀의 SpriteRenderer 배열

    void Start()
    {
        // 그리드 배열 초기화
        grid = new int[gridSize, gridSize];
        cellRenderers = new SpriteRenderer[gridSize, gridSize];

        // 각 셀의 SpriteRenderer 컴포넌트를 설정하고 초기 상태를 설정합니다.
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                GameObject cell = new GameObject("Cell_" + i + "_" + j);
                cell.transform.position = new Vector3(i, j, 0); // 셀의 위치 설정

                SpriteRenderer renderer = cell.AddComponent<SpriteRenderer>();
                renderer.sprite = Resources.Load<Sprite>("CellSprite"); // 셀의 스프라이트 설정
                renderer.color = Color.white; // 초기 색상 설정

                cellRenderers[i, j] = renderer;

                // 초기 불 상태를 설정합니다. 랜덤하게 초기화하거나 특정 위치에서 불이 발생하는 등의 방식으로 설정 가능합니다.
                if (Random.value < 0.1f)
                {
                    grid[i, j] = 1; // 불이 있는 셀로 설정
                    renderer.color = Color.red; // 불의 색상으로 변경
                }
            }
        }

        // 주기적으로 확산을 업데이트합니다.
        InvokeRepeating("UpdateFirePropagation", 0f, 1f);
    }

    void UpdateFirePropagation()
    {
        int[,] newGrid = new int[gridSize, gridSize]; // 새로운 그리드 배열 생성

        // 각 셀에 대해 불의 확산을 계산합니다.
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                // 현재 셀의 상태를 가져옵니다.
                int currentState = grid[i, j];

                // 현재 셀이 불이 아닌 경우, 확산하지 않습니다.
                if (currentState != 1)
                    continue;

                // 이웃한 셀에 불을 확산합니다.
                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        // 이웃한 셀의 좌표를 계산합니다.
                        int ni = i + dx;
                        int nj = j + dy;

                        // 그리드 범위 내에 있는지 확인합니다.
                        if (ni >= 0 && ni < gridSize && nj >= 0 && nj < gridSize)
                        {
                            // 이웃한 셀이 불이 아니고, 이미 불이 퍼져있지 않은 경우에만 확산합니다.
                            if (grid[ni, nj] != 1 && Random.value < propagationRate)
                            {
                                newGrid[ni, nj] = 1; // 불이 확산됨을 표시합니다.
                                cellRenderers[ni, nj].color = Color.red; // 색상을 변경하여 불이 있는 것처럼 표시합니다.
                            }
                        }
                    }
                }
            }
        }

        // 새로운 그리드로 업데이트합니다.
        grid = newGrid;
    }
}
