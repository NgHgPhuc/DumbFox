using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    List<Items> inv;
    public Image image;
    public Transform InventoryTemplete;

    public Sprite Winds;
    public Sprite Boots;
    public Sprite Sword;
    public Sprite Skull;
    public Sprite Slime;
    public Sprite Ball;

    void Start()
    {
    }
    void Update()
    {    
    }
    public PlayerInventory()
    {
        inv = new List<Items>();
    }
    public void AddItemInInventory(Items items)
    {
        inv.Add(items);
    }
    public List<Items> GetInventory()
    {
        return inv;
    }

    Sprite GetSprite(int id)
    {
        switch(id)
        {
            default:
            case 1: return Winds;
            case 2: return Boots;
            case 3: return Sword;
            case 4: return Skull;
            case 5: return Slime;
            case 6: return Ball;
        }
    }
    public void UpdateInventory()
    {
        int x = 0;
        int y = 0;
        Vector2 Nextpos;

        foreach (Items item in inv)
        {
            Nextpos = new Vector2(-127.7f + x * 86f, 163.8f - y * 81f);//85.1 79.9
            Image im = Instantiate(image, InventoryTemplete);
            InfoImage ii = im.GetComponent<InfoImage>();
            ii.SetII(item);

            RectTransform itemslot = im.GetComponent<RectTransform>();
            itemslot.gameObject.SetActive(true);
            itemslot.anchoredPosition = Nextpos;
        
            im.sprite = GetSprite(item.IDItem);


            x++;
            if (x > 3)
            {
                x = 0;
                y++;
            }

        }
    }
    public void Delete2Inventory()
    {
        Destroy(InventoryTemplete.Find("Image(Clone)").gameObject);
    }
}
