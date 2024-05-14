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
        FireExtinguisher
    }
    // ������Ʈâ���� ����
    public ItemType type = ItemType.Bucket; 

    //Ư�� ��ҿ� ����ؾ��ϴ� �������ϰ��
    //�������� �� ä�� �ش� Ÿ�� ������Ʈ�� Raycast Hit �ÿ��� ��밡��
    [SerializeField] Transform target;
    [SerializeField] Transform trigger;

    //[SerializeField] GameObject Use_effect;
    [SerializeField] List<GameObject> target_Use_effect;
    [SerializeField] GameObject target_Use_image;

    private Color image_color;

    public bool item_used = false; // �ѹ� ����Ѱ� ������ϰ� �ϴ� �뵵
    public bool FE_opened = false; // ��ȭ�� ������ �����Ǿ����� üũ 
    [SerializeField] FEClickParticleSystem fEClickParticleSystem;

    public void Use(ItemType type)
    {
        switch (type)
        {
            case ItemType.Bucket:
                BucketUse();
                //Debug.Log("Bucket �������� ����߽��ϴ�.");
                break;
            case ItemType.FireExtinguisher:
                if (!item_used)
                {
                    FEUse();
                    //Debug.Log("Fire �������� ����߽��ϴ�.");
                }
                else
                    fEClickParticleSystem.UsingFE();
                break;
            default:
                // �� �� ���� ������ ������ ���� ó��
                Debug.LogError("�� �� ���� ������ �����Դϴ�.");
                break;
        }
    }

    void BucketUse()
    {
        Transform water = gameObject.transform.GetChild(0);
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            //target : �������� ���� ��ȭ���� (�� ������ �ȵǴ°�)
            //trigger : ���� ���� �� �ִ°�
            if (hit.transform.tag == "ElecFire" && water.gameObject.activeSelf)
            {
                water.gameObject.SetActive(false);
                
                Time.timeScale = 0.0f;
                for (int i = 0; i < target_Use_effect.Count; i++)
                {
                    target_Use_effect[i].SetActive(true);
                }
                StartCoroutine(RedFadeInOutforBadEnding());
                //Debug.Log("���");
            }
            else if (hit.transform == trigger)
            {
                water.gameObject.SetActive(true);
                //Debug.Log("�� ä����");
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
                //Debug.Log("�� ���");
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
                // ��ȭ�� ������� ���� ���� UI
                target_Use_image.SetActive(true);
                SojaExiles.MouseLook.Instance.mouseLock = true;

            }
            
        }
    }

    IEnumerator RedFadeInOutforBadEnding()
    {
        float startTime = Time.realtimeSinceStartup;
        image_color = target_Use_image.GetComponent<Image>().color;

        // ���� ��� �ð��� ����Ͽ� �̹��� fadein
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

        //Time.timeScale = 1f; // 3�ʰ� ���� �Ŀ� ������� �ð��� �ٽ� �帣�� ���� ���߿� ���⼭ ���������� ������
        
        Debug.Log("��忣��");
    }

}
