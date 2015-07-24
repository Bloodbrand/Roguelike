using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class input : MonoBehaviour
{
    public float minSwipe = Screen.height / 10;
    Vector2 beginPosition;
    Vector2 endPosition;

    float swipeDistance = 0;
    float holdTime = 0;
    float minHoldTime = 1.0f;
    bool swiped = false;
    bool holding = false;
    bool holdFullyLoaded = false;


	void Update ()
    {
        manageSwipe();
        manageHold();
        //manageClick();
	}

    void manageClick()
    {

        if (Input.GetMouseButtonDown(0))
        {
            GameMaster.uiComp.addChargerUI(Input.mousePosition);
            GameMaster.playerComp.CastHold(Input.mousePosition);
            beginPosition = Input.mousePosition;
            endPosition = beginPosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            GameMaster.uiComp.removeChargerUI();
            endPosition = Input.mousePosition; 
            swiped = false;
        }

        swipeDistance = Vector2.Distance(beginPosition, endPosition);

        if (swipeDistance > minSwipe && !swiped)
        {
            float angle = Mathf.Atan2(endPosition.x - beginPosition.x, endPosition.y - beginPosition.y) * Mathf.Rad2Deg;
            GameMaster.playerComp.CastSwipe(beginPosition, angle);
            swiped = true;
        }
    }

    void manageSwipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) swiped = false;

        if (swiped) return;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            beginPosition = Input.GetTouch(0).position;
            endPosition = beginPosition;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            endPosition = Input.GetTouch(0).position; 

        swipeDistance = Vector2.Distance(beginPosition, endPosition);

        if (swipeDistance > minSwipe)
        {
            float angle = Mathf.Atan2(endPosition.x - beginPosition.x, endPosition.y - beginPosition.y) * Mathf.Rad2Deg;
            GameMaster.playerComp.CastSwipe(beginPosition, angle);
            swiped = true;
            holding = false;
            holdTime = 0;
        }
    }

    void manageHold()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            holding = true;
            GameMaster.uiComp.addChargerUI(Input.GetTouch(0).position);
        }
           

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            holding = false;
            holdTime = 0;
            GameMaster.uiComp.removeChargerUI();

            if (holdFullyLoaded)
            {
                holdFullyLoaded = false;
                holding = false;
                holdTime = 0;

                GameMaster.playerComp.CastHold(Input.GetTouch(0).position);
            }
        }

        if (!holding) return;

        holdTime += Time.deltaTime;

        GameMaster.uiComp.chargeLoaderUI(holdTime / minHoldTime);

        if (holdTime >= minHoldTime)
            holdFullyLoaded = true;
    }
}