using System;
using System.IO;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;


class Helper : MonoBehaviour
{
    System.Random r = new System.Random();

    /**
     * 
     */
    public string readStringFromPath(string path)
    {
        string stringContent = "";

        using (StreamReader stream = new StreamReader(path)) {
            stringContent = stream.ReadToEnd();
        }

        return stringContent;
    }

    /**
     * 
     */
    public int getRandomIndexFromList(int listSize)
    {
        if (listSize == 0 || listSize == 1) {
            return 0;
        }

        return r.Next(0, listSize - 1);
    }

    /*
     * Replaces Sprite in a GameObject
     */
    public void replaceSprite(ref GameObject gameObject, string spritePath)
    {
        spritePath = spritePath.Replace(".png", "");
        spritePath = spritePath.Replace(".jpeg", "");

//        Debug.Log("spritePath: " + spritePath);

        Sprite objectSprite = Resources.Load<Sprite>(spritePath);
        SpriteRenderer objectSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        objectSpriteRenderer.sprite = objectSprite;
    }

    /*
     * Replaces audio clip in a GameObject
     */
    public void replaceAudioClip(ref GameObject gameObject, string audioAudioClipPath)
    {
        audioAudioClipPath = audioAudioClipPath.Replace(".mp3", "");
        audioAudioClipPath = audioAudioClipPath.Replace(".wav", "");

        AudioClip objectAudioClip = Resources.Load<AudioClip>(audioAudioClipPath);
        AudioSource objectAudioSource = gameObject.GetComponent<AudioSource>();

        objectAudioSource.clip = objectAudioClip;
    }

    public Vector2 GetAspectRatio(int x, int y, bool debug)
    {
        float f = (float) x / (float) y;
        int i = 0;

        while (true) {
            i++;

            if (System.Math.Round(f * i, 2) == Mathf.RoundToInt(f * i)) {
                break;
            }
        }

        var aspectX = f * i;
        var aspectY = i;

        //condition for 20
        if (aspectX <= 2) {
            aspectX *= 10;
        }

        if (aspectY <= 2) {
            aspectY *= 10;
        }

        if (debug) {
            Debug.Log("Aspect ratio is " + aspectX + ":" + aspectY + " (Resolution: " + x + "x" + y + ")");
        }


        return new Vector2((int) System.Math.Round(f * i, 0), i);
    }


    /**
     * 
     */
    public Vector2 CorrectPositionBasedOnAspectRatio(Vector2 position, Vector2 aspect, bool debug = false)
    {
        //How much distance to have between the screen margin and the object
        const float margin = 0.1f;

        var x = position.x;
        var y = position.y;
        var aspectX = aspect.x;
        var aspectY = aspect.y;


        //condition for 20
        if (aspectX <= 2f) {
            aspectX *= 10f;
        }

        if (aspectY <= 2f) {
            aspectY *= 10f;
        }

//        Debug.Log("-------START----------");
//        Debug.Log("aspectX: " + aspectX);
//        Debug.Log("aspectY: " + aspectY);

        if (aspectX < Math.Abs(x)) {
            var diffX = Math.Abs(x) - aspectX;

            Debug.Log("diffX " + diffX);

            if (Math.Sign(x) == -1) {
//                Debug.Log("x is negative ");
//                Debug.Log("diff: " + (diffX * -1));
//                Debug.Log("margin: " + (margin * -1));
                x = x - (diffX * -1) - (margin * -1);
            } else {
//                Debug.Log("x is positive ");
                x = x - Math.Abs(diffX) - Math.Abs(margin);
            }
        }

        if (aspectY < Math.Abs(y)) {
            var diffY = Math.Abs(y) - aspectY;

//            Debug.Log("diffY " + diffY);

            if (Math.Sign(x) == -1) {
                y = y - (diffY * -1) - (margin * -1);
            } else {
                y = y + Math.Abs(diffY) - Math.Abs(margin);
            }
        }

        if (debug) {
//            Debug.Log("-- CorrectPositionBasedOnAspectRatio --");
//            Debug.Log("Original Position: x: " + position.x + " / y:" + position.y);
//            Debug.Log("Corrected Position: x: " + x + " / y:" + y);
//            Debug.Log("------------");
        }

        return new Vector2(x, y);
    }


    /**
     * 
     */
    public void ShuffleList<E>(IList<E> list)
    {
        System.Random random = new System.Random();

        if (list.Count > 1) {
            for (int i = list.Count - 1; i >= 0; i--) {
                E tmp = list[i];
                int randomIndex = random.Next(i + 1);

                //Swap elements
                list[i] = list[randomIndex];
                list[randomIndex] = tmp;
            }
        }
    }

    /**
     * 
     */
    public static string ConvertToTimestamp(int value, string unit)
    {
        switch (unit) {
            case "hours":
                return TimeSpan.FromHours(value).ToString();

            case "minutes":
                return TimeSpan.FromMinutes(value).ToString();

            case "seconds":
                return TimeSpan.FromSeconds(value).ToString();

            case "milliseconds":
                return TimeSpan.FromMilliseconds(value).ToString();
                
        }
        
        return "00:00:00";
    }

    /**
     * 
     */
    public static GameObject FindChildByName(Transform parent, string name)
    {

        foreach (Transform child in parent) {
            if (child.name == name) {
                return child.gameObject;
            }
        }

        return null;
    }

    public static void DestroyGameObjects(GameObject[] objects)
    {
        for (var i = 0; i < objects.Length; i++) {
            Destroy(objects[i]);
        }    
    }
    
    //RECT UTILS
    
    public static void SetLeft(ref RectTransform rt, float left)
    {
        rt.offsetMin = new Vector2(left, rt.offsetMin.y);
    }
 
    public static void SetRight(ref RectTransform rt, float right)
    {
        rt.offsetMax = new Vector2(-right, rt.offsetMax.y);
    }
 
    public static void SetTop(ref RectTransform rt, float top)
    {
        rt.offsetMax = new Vector2(rt.offsetMax.x, -top);
    }
 
    public static void SetBottom(ref RectTransform rt, float bottom)
    {
        rt.offsetMin = new Vector2(rt.offsetMin.x, bottom);
    }
    
    public static void SetAll(ref RectTransform rt, float left, float right, float top, float bottom)
    {
        rt.offsetMin = new Vector2(left, rt.offsetMin.y);
        rt.offsetMax = new Vector2(right, rt.offsetMax.y);
        rt.offsetMax = new Vector2(rt.offsetMax.x, top);
        rt.offsetMin = new Vector2(rt.offsetMin.x, bottom);
    }
    
    public static void SetHeight(ref RectTransform rt, int height)
    {
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, height);
    }
    // END RECT UTILS
    
    
    
    
    
    
}