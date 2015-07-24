using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ui : MonoBehaviour {
    public GameObject chargeLoader;
    public GameObject heart;
    public Image chargerFillImage;

    public List<Image> heartImages;
    float heartDistance = 5.0f; //between each other
    float heartTopBuffer = 3.0f; 

    public void addHearts()
    {
        heartImages = new List<Image>();
        float num = GameMaster.FindPlayer().health;

        for (int i = 0; i < num; i++)
        {
            GameObject newHeart = Instantiate(heart) as GameObject;
            RectTransform rt = newHeart.GetComponent<RectTransform>();
            float width = rt.rect.width;
            float height = rt.rect.height;

            rt.pivot = new Vector2(0.0f, 0.5f);
            rt.position = new Vector3((width * i) + (heartDistance * (i + 1)), -(height / 2) - heartTopBuffer, 0.0f);
            newHeart.transform.SetParent(transform, false);
            heartImages.Add(newHeart.GetComponent<Image>());
        }
    }

    public void addChargerUI(Vector3 pos)
    {
        GameObject newCharger = Instantiate(chargeLoader) as GameObject;
        newCharger.transform.SetParent(transform, false);
        newCharger.transform.SetAsFirstSibling();
        RectTransform rt = newCharger.GetComponent<RectTransform>();
        rt.position = pos;
        chargerFillImage = newCharger.transform.FindChild("chargerFill").GetComponent<Image>();
    }

    public void removeChargerUI()
    {
        GameObject chargerUI = transform.FindChild("chargerStroke(Clone)").gameObject;
        Destroy(chargerUI);
    }

    public void takeDamageUI(float damage)
    {
        if (heartImages.Count == 0) return;
        Image lastHeart = returnLastHeart();

        if (damage > lastHeart.fillAmount)
        {
            damage -= lastHeart.fillAmount;
            removeLastHeart(); 
            lastHeart = returnLastHeart();
            lastHeart.fillAmount -= damage;
        }
        else lastHeart.fillAmount -= damage;

        if (heartImages[heartImages.Count - 1].fillAmount <= 0) removeLastHeart();
    }

    Image returnLastHeart()
    {
        return heartImages[heartImages.Count - 1];
    }

    void removeLastHeart()
    {
        Image lastHeart = returnLastHeart();
        lastHeart.fillAmount = 0;
        heartImages.RemoveAt(heartImages.Count - 1);
    }

    public void chargeLoaderUI(float fill)
    {
        chargerFillImage.fillAmount = fill;
    }
}
