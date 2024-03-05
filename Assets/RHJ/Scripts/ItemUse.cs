using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUse : MonoBehaviour
{
    public enum ItemType
    {
        Bucket,
        Fire
    }
    //컴포넌트창에서 변경
    public ItemType type = ItemType.Bucket; 

    //특정 장소에 사용해야하는 아이템일경우
    //아이템을 든 채로 해당 타겟 오브젝트에 Raycast Hit 시에만 사용가능
    [SerializeField] Transform target;
    [SerializeField] Transform trigger;

    [SerializeField] GameObject Use_effect;
    [SerializeField] List<GameObject> target_Use_effect;
    [SerializeField] GameObject target_Use_image;

    private Color image_color;

    public void Use(ItemType type)
    {
        switch (type)
        {
            case ItemType.Bucket:
                BucketUse();
                //Debug.Log("Bucket 아이템을 사용했습니다.");
                break;
            case ItemType.Fire:
                // Fire 아이템 사용에 대한 동작 추가
                Debug.Log("Fire 아이템을 사용했습니다.");
                break;
            default:
                // 알 수 없는 아이템 유형에 대한 처리
                Debug.LogError("알 수 없는 아이템 유형입니다.");
                break;
        }
    }

    void BucketUse()
    {
        Transform water = gameObject.transform.GetChild(0);
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            //target : 누전으로 인한 발화지점 (물 버리면 안되는곳)
            //trigger : 물을 받을 수 있는곳
            if (hit.transform == target)
            {
                water.gameObject.SetActive(false);
                
                Time.timeScale = 0.0f;
                for (int i = 0; i < target_Use_effect.Count; i++)
                {
                    target_Use_effect[i].SetActive(true);
                }
                StartCoroutine(RedFadeInOutforBadEnding());
                Debug.Log("쥬금");
            }
            else if (hit.transform == trigger)
            {
                water.gameObject.SetActive(true);
                Debug.Log("물 채워짐");
            }
            else
            {
                water.gameObject.SetActive(false);
                Debug.Log("물 사용");
            }
        }       
        
    }

    IEnumerator RedFadeInOutforBadEnding()
    {
        float startTime = Time.realtimeSinceStartup;
        image_color = target_Use_image.GetComponent<Image>().color;

        // 실제 경과 시간을 사용하여 이미지 fadein
        while (Time.realtimeSinceStartup - startTime < 1f)
        {
            target_Use_image.GetComponent<Image>().color = new Color(image_color.r, image_color.g, image_color.b, Mathf.Lerp(1, 0, Time.realtimeSinceStartup - startTime));
            yield return null;
        }
        //fadeout
        startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup - startTime < 2f)
        {
            target_Use_image.GetComponent<Image>().color = new Color(image_color.r, image_color.g, image_color.b, Mathf.Lerp(0, 0.7f, Time.realtimeSinceStartup - startTime));
            yield return null;
        }

        Time.timeScale = 1f; // 3초가 지난 후에 원래대로 시간을 다시 흐르게 설정 나중에 여기서 엔딩씬으로 보내기
        
        Debug.Log("배드엔딩");
    }

}
