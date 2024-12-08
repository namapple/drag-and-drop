using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoadImageUniTask : MonoBehaviour
{
    [SerializeField] private Image[] images = new Image[3];

    // public string url = "https://i1-vnexpress.vnecdn.net/2024/12/08/DSC4158-6086-1733621893.jpg?w=1020&h=0&q=100&dpr=1&fit=crop&s=EMcUQyZubzRV3KUJAaHqiQ";

    public string[] urls = new string[3];
    
    
    private void Start()
    {
        LoadImages().Forget();
    }

    private async UniTask<Sprite> LoadImage(string url, CancellationToken token = default)
    {
        var unityWebRequestTexture = await UnityWebRequestTexture
            .GetTexture(url)
            .SendWebRequest()
            .WithCancellation(token);
        
        Texture2D texture = ((DownloadHandlerTexture)unityWebRequestTexture.downloadHandler).texture;
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2());
        
        return sprite;
    }

    
    // when calling a UniTask, this should be done through an async UniTaskVoid instead of a async void method, because otherwise it won't run through UniTask!
    private async UniTaskVoid LoadImages()
    {
        List<UniTask<Sprite>> tasks = new List<UniTask<Sprite>>();
        foreach (var url in urls)
        {
            tasks.Add(LoadImage(url, this.GetCancellationTokenOnDestroy()));
        }
        
        Sprite[] sprites = await UniTask.WhenAll(tasks);
        for (int i = 0; i < images.Length; i++)
        {
            images[i].sprite = sprites[i];
            images[i].preserveAspect = true;
        }
    }

    private async UniTask<string> GetWebRequest(string url, CancellationToken token)
    {
        var op = await UnityWebRequest
            .Get(url)
            .SendWebRequest()
            .WithCancellation(token);
        
        string result = op.downloadHandler.text;
        Debug.LogError("result: " + result);
        return result;
    }

}