using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowelEquipping : MonoBehaviour
{
    private bool isMousePressed = false;
    private Coroutine moveCoroutine;

    [SerializeField] Transform EquippedTowel;
    [SerializeField] Transform UnEquippedTowel;
    public bool grabbingTowel = false;
     

    void Update()
    {

        if (grabbingTowel)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isMousePressed = true;
                moveCoroutine = StartCoroutine(MoveObjectCoroutine());
            }

            else if (Input.GetMouseButtonUp(0))
            {
                gameObject.transform.position = UnEquippedTowel.position;
                isMousePressed = false;
                if (moveCoroutine != null)
                    StopCoroutine(moveCoroutine);
            }
        }
        
    }

    IEnumerator MoveObjectCoroutine()
    {
        while (isMousePressed)
        {
            transform.position = EquippedTowel.position;
            yield return null;
        }
    }
}
