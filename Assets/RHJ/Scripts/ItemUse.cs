using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngineInternal;

public class ItemUse : MonoBehaviour
{
    public enum ItemType
    {
        Bucket,
        FireExtinguisher,
        Towel
    }
    // 컴포넌트창에서 변경
    public ItemType type = ItemType.Bucket; 

    //특정 장소에 사용해야하는 아이템일경우
    //아이템을 든 채로 해당 타겟 오브젝트에 Raycast Hit 시에만 사용가능
    [SerializeField] Transform target;
    [SerializeField] Transform trigger;

    //[SerializeField] GameObject Use_effect;
    [SerializeField] List<GameObject> target_Use_effect;
    [SerializeField] GameObject target_Use_image;

    private Color image_color;

    public bool item_used = false; // 한번 사용한것 못사용하게 하는 용도
    public bool FE_opened = false; // 소화기 안전핀 해제되었는지 체크 
    [SerializeField] FEClickParticleSystem fEClickParticleSystem;

    public void Use(ItemType type)
    {
        switch (type)
        {
            case ItemType.Bucket:
                BucketUse();
                //Debug.Log("Bucket 아이템을 사용했습니다.");
                break;
            case ItemType.FireExtinguisher:
                if (!item_used)
                {
                    FEUse();
                    //Debug.Log("Fire 아이템을 사용했습니다.");
                }
                else
                    fEClickParticleSystem.UsingFE();
                break;
            case ItemType.Towel:
                if (!item_used)
                {
                    TowelUseWithoutWater();
                }
                else
                    TowelUseWithWater();
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
            if (hit.transform.tag == "ElecFire" && water.gameObject.activeSelf)
            {
                water.gameObject.SetActive(false);
                
                Time.timeScale = 0.0f;
                for (int i = 0; i < target_Use_effect.Count; i++)
                {
                    target_Use_effect[i].SetActive(true);
                }
                StartCoroutine(RedFadeInOutforBadEnding());
                //Debug.Log("쥬금");
            }
            else if (hit.transform == trigger)
            {
                water.gameObject.SetActive(true);
                //Debug.Log("물 채워짐");
            }
            else if (hit.transform.tag == "Fire")
            {
                UIManager.Instance.UI[0].SetActive(true);
                hit.transform.parent.gameObject.SetActive(false);
                water.gameObject.SetActive(false);
            }
            else if (hit.transform.tag == "BigFire")
            {
                UIManager.Instance.UI[1].SetActive(true);
                water.gameObject.SetActive(false);
            }

            else
            {
                water.gameObject.SetActive(false);
                //Debug.Log("물 사용");
            }
        }       
        
    }

    void FEUse()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            //target : fire
            if (hit.transform.tag == "ElecFire" || hit.transform.tag == "Fire" || hit.transform.tag == "BigFire")
            {
                // 소화기 사용할지 여부 묻는 UI
                target_Use_image.SetActive(true);
                SojaExiles.MouseLook.Instance.mouseLock = true;

            }
            
        }
    }

    void TowelUseWithoutWater()
    {
        target_Use_effect[0].SetActive(true);
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            //water hit
            if (hit.transform.tag == "water")
            {
                Debug.Log("물");
                target_Use_effect[1].SetActive(true);
                gameObject.transform.GetComponent<MeshRenderer>().enabled = false;
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                item_used = true;

            }
            else 
            { 
                target_Use_effect[0].SetActive(true);
                Debug.Log("사용");
            }
        }
    }

    void TowelUseWithWater()
    {
        target_Use_effect[2].SetActive(true);
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

        // BadEnding 1 : Electirc shock ending

        ScoreManager.Instance.PlayerViewedEnding(1);

        //Time.timeScale = 1f; // 3초가 지난 후에 원래대로 시간을 다시 흐르게 설정 나중에 여기서 엔딩씬으로 보내기
        
        Debug.Log("배드엔딩");
    }

}
