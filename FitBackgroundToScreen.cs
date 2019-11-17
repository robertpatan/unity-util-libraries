using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitBackgroundToScreen : MonoBehaviour
{
    public Camera mainCam;
    public SpriteRenderer backgroundImage;

    // Start is called before the first frame update
    void Start()
    {
        fitBackgroundImage();    
    }

    private void fitBackgroundImage() {
        //Get device aspect ratio
        Vector2 deviceScreenResolution = new Vector2(Screen.width, Screen.height);

        float scrHeight = Screen.height;
        float scrWdith = Screen.width;

        float DEVICE_SCREEN_ASPECT = scrWdith / scrHeight;

        //Set main camera aspect ratio = device ratio
        mainCam.aspect = DEVICE_SCREEN_ASPECT;

        // Scale BG Image to fit Camera size
        float camHeight = 100.0f * mainCam.orthographicSize * 2.0f;
        float camWidth = camHeight * DEVICE_SCREEN_ASPECT;

        //Get background imageSize
        SpriteRenderer backgroundImageSR = backgroundImage.GetComponent<SpriteRenderer>();
        float bigImgH = backgroundImageSR.sprite.rect.height;
        float bigImgW = backgroundImageSR.sprite.rect.width;

        //Calculate ratio for scalling
        float bigImgScaleRatioHeight = camHeight / bigImgH;
        float bigImgScaleRatioWidth = camWidth / bigImgW;

        backgroundImage.transform.localScale = new Vector3(bigImgScaleRatioWidth, bigImgScaleRatioHeight, 1);

    }
}
