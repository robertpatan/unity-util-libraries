using System;
using System.Collections;
using UnityEngine;

public class FxManager : MonoBehaviour
{
    public Fx[] effects;


    private static FxManager instance;
    private const int destroyAfterSeconds = 10;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        //persists object when changing scenes
        DontDestroyOnLoad(gameObject);
    }

    public void PlayWithPosition(string name, Vector2 position)
    {
        var effect = Find(name);

        if (effect == null)
        {
            Debug.LogWarning("Effect with name: " + name + " was not found");
            return;
        }

        var fxObject = Instantiate(effect.prefab, position, Quaternion.identity);
        fxObject.GetComponent<ParticleSystem>().Play();

        StartCoroutine(DestroyFx(fxObject));
    }

    public void Play(string name)
    {
        var effect = Find(name);

        if (effect == null)
        {
            Debug.LogWarning("Effect with name: " + name + " was not found");
            return;
        }

        var fxObject = Instantiate(effect.prefab);
        fxObject.GetComponent<ParticleSystem>().Play();

        StartCoroutine(DestroyFx(fxObject));
    }

    private Fx Find(string name)
    {
        return Array.Find(effects, fx => fx.name == name);
    }

    IEnumerator DestroyFx(GameObject fx)
    {
        yield return new WaitForSeconds(destroyAfterSeconds);

        Destroy(fx);
    }
}