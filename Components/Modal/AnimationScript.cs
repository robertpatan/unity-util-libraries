using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{

    public Modal modal;
    
    public void Show()
    {
        modal.ShowPanel();    
    }

    public void Hide()
    {
        modal.HidePanel();       
    }
}
