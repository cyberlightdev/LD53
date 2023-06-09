using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f, 2.0f)]
    private float radius = 0.25f;

    [SerializeField]
    [Range (0, 10)]
    private int maxItems = 2;

    [SerializeField]
    [Range(0, 100f)]
    private float rotationSpeed = 0.5f;

    private Vector3[] points;

    [SerializeField]
    private Stack<GameObject> items;

    private void Awake()
    {
        points = new Vector3[maxItems];
        items = new Stack<GameObject>();

        for (int i = 0; i < maxItems; i++)
        {
            float angle = i * Mathf.PI * 2f / maxItems;
            points[i] = new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * radius;
        }
    }

    public void Push(GameObject item)
    {
        GameObject go = Instantiate(item, transform);
        go.transform.localPosition = points[items.Count];
        items.Push(go);
    }

    public void Push(Item item)
    {
        GameObject go = Instantiate(item.model, transform);
        go.transform.localPosition = points[items.Count];
        go.transform.localScale = item.AutoRescale(this.gameObject.GetComponentInParent<Transform>());
        items.Push(go);
    }

    public GameObject Pop()
    {
        return items.Pop();
    }

    private void Update()
    {
        if(items.Count > 0)
        {
           transform.Rotate(0f, rotationSpeed * 10f * Time.deltaTime, 0f, Space.Self);
        }
    }


}
