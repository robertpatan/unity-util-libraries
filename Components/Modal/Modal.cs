using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Modal : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI content;
    public GameObject panel;
    public GameObject modal;
    public int height;

    public Animator animator;
    
    


    // Start is called before the first frame update
    void Start()
    {
        animator = modal.GetComponent<Animator>();
        SetHeight(height);
        gameObject.SetActive(false);
        HidePanel();
    }
    
    public void SetModal(string title, string content, int modalHeight = 0)
    {
       SetTitle(title);
       SetContent(content);
       
       if (modalHeight > 0) {
           SetHeight(modalHeight);    
       }
    }
    

    public void SetTitle(string text)
    {
        title.SetText(text);
    }
    
    public void SetContent(string text)
    {
        content.SetText(text);
    }

    public void SetHeight(int value)
    {
        RectTransform modalRect = modal.GetComponent<RectTransform>();
        Helper.SetHeight(ref modalRect, value);
    }
    
    public void Show()
    {
        gameObject.SetActive(true);
        ShowPanel();
//        animator.Play("InAnimation");
       
    }

    public void Hide()
    {
        animator.Play("OutAnimation");

        StartCoroutine(HideDelayed(0.5f));


    }
    
    public void OnClose()
    {
        Hide();
    }
    
    public void OnConfirm()
    {
        Hide();
        //define logic here
    }
    
    public void ShowPanel()
    {
        panel.SetActive(true);
    }

    public void HidePanel()
    {
        panel.SetActive(false);
    }

    IEnumerator HideDelayed(float time)
    {
        yield return new WaitForSeconds(time);
        
        panel.SetActive(false);
        gameObject.SetActive(false);
        
    }
    
    
}