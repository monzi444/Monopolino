using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropertiesManager : MonoBehaviour
{
    public GameObject map;
    public GameObject priceTag;
    public GameObject priceValueText;

    private void Awake()
    {
        //Gets all childrens transform
        for (int i = 0; i < map.transform.childCount; i++)
        {
            Transform childrenTransform = map.transform.GetChild(i);

            if (childrenTransform.name.Contains("Property") || childrenTransform.name.Contains("Company") || childrenTransform.name.Contains("Airport"))
            {
                var priceTagInstance = Instantiate(priceTag, childrenTransform.position, Quaternion.identity);
                priceTagInstance.name = "PriceTag";
                priceTagInstance.transform.parent = childrenTransform.transform;
                priceTagInstance.transform.position = new Vector3(priceTagInstance.transform.position.x, priceTagInstance.transform.position.y + 1.75f, priceTagInstance.transform.position.z - 1);

                var priceValueTextInstance = Instantiate(priceValueText, childrenTransform.transform.position, Quaternion.identity);
                priceValueTextInstance.name = "PriceValueText";
                priceValueTextInstance.transform.parent = childrenTransform.transform;
                priceValueTextInstance.transform.position = new Vector3(priceValueTextInstance.transform.position.x, priceValueTextInstance.transform.position.y + 1.75f, priceValueTextInstance.transform.position.z - 1);
            }
        }
    }
}
