using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyitemsui : MonoBehaviour
{
    [SerializeField] private keyholder keyHolder;
    private Transform container;
    private Transform keytemplate;
    

    private void Awake()
    {
        container = transform.Find("container");
        keytemplate = container.Find("keytemplate");
        keytemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        keyHolder.OnKeysChanged += keyholder_OnKeysChanged;
    }

    private void keyholder_OnKeysChanged(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach (Transform child in container)
        {
            if (child == keytemplate) continue;
            Destroy(child.gameObject);
        }
        List<key.KeyType> keyList = keyHolder.GetKeyList();
        for (int i = 0; i < keyList.Count; i++)
        {
            key.KeyType keyType = keyList[i];
            Transform keyTransform = Instantiate(keytemplate, container);
            keytemplate.gameObject.SetActive(true);
            keyTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(50 * i, 0);
            Image keyImage = keyTransform.Find("image").GetComponent<Image>();
            switch (keyType)
            {
            default:
            case key.KeyType.Zero: keyImage.color = Color.black;    break;
            case key.KeyType.One: keyImage.color = Color.yellow;    break;
            case key.KeyType.Two: keyImage.color = Color.red;   break;

            }
        }
    }
}
