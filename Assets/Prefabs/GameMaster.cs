using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
    public static ui uiComp;
    public static Player playerComp;
    public static Camera cam;
    public static float cameraY;

	void Start () {
        cam = Camera.main;
        cameraY = cam.transform.position.y;
        Screen.orientation = ScreenOrientation.Portrait;
        uiComp = FindUI();
        playerComp = FindPlayer();
        uiComp.addHearts();
	}

    public ui FindUI()
    {
        return GameObject.Find("Canvas").GetComponent<ui>();       
    }

    public static Player FindPlayer()
    {
        return GameObject.Find("GameMaster").GetComponent<Player>();
    }
}
