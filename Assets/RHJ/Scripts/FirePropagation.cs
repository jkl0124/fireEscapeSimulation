using UnityEngine;

public class FirePropagation : MonoBehaviour
{
    
    public int gridSize = 10; // �׸��� ũ��
    public float propagationRate = 0.6f; // ���� Ȯ�� �ӵ�
    private int[,] grid; // ���� ���¸� �����ϴ� �׸��� �迭
    private SpriteRenderer[,] cellRenderers; // �� ���� SpriteRenderer �迭

    void Start()
    {
        // �׸��� �迭 �ʱ�ȭ
        grid = new int[gridSize, gridSize];
        cellRenderers = new SpriteRenderer[gridSize, gridSize];

        // �� ���� SpriteRenderer ������Ʈ�� �����ϰ� �ʱ� ���¸� �����մϴ�.
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                GameObject cell = new GameObject("Cell_" + i + "_" + j);
                cell.transform.position = new Vector3(i, j, 0); // ���� ��ġ ����

                SpriteRenderer renderer = cell.AddComponent<SpriteRenderer>();
                renderer.sprite = Resources.Load<Sprite>("CellSprite"); // ���� ��������Ʈ ����
                renderer.color = Color.white; // �ʱ� ���� ����

                cellRenderers[i, j] = renderer;

                // �ʱ� �� ���¸� �����մϴ�. �����ϰ� �ʱ�ȭ�ϰų� Ư�� ��ġ���� ���� �߻��ϴ� ���� ������� ���� �����մϴ�.
                if (Random.value < 0.1f)
                {
                    grid[i, j] = 1; // ���� �ִ� ���� ����
                    renderer.color = Color.red; // ���� �������� ����
                }
            }
        }

        // �ֱ������� Ȯ���� ������Ʈ�մϴ�.
        InvokeRepeating("UpdateFirePropagation", 0f, 1f);
    }

    void UpdateFirePropagation()
    {
        int[,] newGrid = new int[gridSize, gridSize]; // ���ο� �׸��� �迭 ����

        // �� ���� ���� ���� Ȯ���� ����մϴ�.
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                // ���� ���� ���¸� �����ɴϴ�.
                int currentState = grid[i, j];

                // ���� ���� ���� �ƴ� ���, Ȯ������ �ʽ��ϴ�.
                if (currentState != 1)
                    continue;

                // �̿��� ���� ���� Ȯ���մϴ�.
                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        // �̿��� ���� ��ǥ�� ����մϴ�.
                        int ni = i + dx;
                        int nj = j + dy;

                        // �׸��� ���� ���� �ִ��� Ȯ���մϴ�.
                        if (ni >= 0 && ni < gridSize && nj >= 0 && nj < gridSize)
                        {
                            // �̿��� ���� ���� �ƴϰ�, �̹� ���� �������� ���� ��쿡�� Ȯ���մϴ�.
                            if (grid[ni, nj] != 1 && Random.value < propagationRate)
                            {
                                newGrid[ni, nj] = 1; // ���� Ȯ����� ǥ���մϴ�.
                                cellRenderers[ni, nj].color = Color.red; // ������ �����Ͽ� ���� �ִ� ��ó�� ǥ���մϴ�.
                            }
                        }
                    }
                }
            }
        }

        // ���ο� �׸���� ������Ʈ�մϴ�.
        grid = newGrid;
    }
}
