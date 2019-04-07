using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QueryManager : MonoBehaviour
{
    public InputField input;
    public Button dym1;
    public Button dym2;
    public Button dym3;
    public GameObject dymPanel;
    public GameObject queryPanel;
    public Text answer;
    int min1;
    int min2;
    int min3;

    string[] itemList;
    int[] answerList;
    string[] itemMap;
    int[] levenArray;

    void Start()
    {
        itemList = new string[] { "paper",
        "newspaper",
        "magazine",
        "catalog",
        "map",
        "phonebook",
        "mail",
        "paperboard",
        "tissue",
        "box",
        "card",
        "folder",
        "can",
        "straw",
        "carton",
        "book",
        "cup",
        "envelope",
        "cardboard",
        "vase",
        "plastic",
        "boxboard",
        "box",
        "metal",
        "tin",
        "aluminum",
        "dish",
        "plate",
        "tray",
        "cookware",
        "copper",
        "jewelry",
        "key",
        "steel",
        "pot",
        "bucket",
        "pan",
        "pyrex",
        "utensil",
        "glass",
        "bottle",
        "jar",
        "cup",
        "jug",
        "metal",
        "spoon",
        "fork",
        "office paper",
        "blind",
        "curtain",

        "fruit",
        "vegetable",
        "apple",
        "pear",
        "banana",
        "cucumber",
        "strawberry",
        "apricots",
        "avocado",
        "blackberry",
        "cherry",
        "coconut",
        "date",
        "durian",
        "dragonfruit",
        "grape",
        "grapefruit",
        "kiwi",
        "lime",
        "lemon",
        "lychee",
        "mango",
        "melon",
        "nectarine",
        "olive",
        "orange",
        "peach",
        "pineapple",
        "plum",
        "pomegranate",
        "pomelo",
        "raspberries",
        "watermelon",
        "broccoflower",
        "broccoli",
        "cabbage",
        "celery",
        "corn",
        "basil",
        "rosemary",
        "sage",
        "thyme",
        "kale",
        "lettuce",
        "mushroom",
        "onion",
        "pepper",
        "ginger",
        "wasabi",
        "squash",
        "tomato",
        "potato",
        "hair",
        "wood",
        "popcorn",
        "leaves",
        "egg",
        "pasta",
        "fish",
        "beef",
        "chicken",
        "pork",
        "meat",
        "soy",
        "pumpkin",
        "nut",
        "cheese",
        "toothpicks",
        "pickles",
        "feather",
        "fur",
        "bone",
        "metal",
        "textile",
        "cloth",

        "battery",
        "computer",
        "electronics",
        "bulb",
        "microfilm",
        "cell phone",
        "phone",
        "mobile phone",
        "equipment",
        "inkjet",
        "cartridge",
        "inkjet cardridge",
        "cd",
        "disk",
        "tire",
        "ink cartridge",
        "tv",
        "power cord",
        "personal computer",
        "laptop",
        "portable computer",

        "nut",
        "carrot",
        
        "milk",
        "napkin",
        "towel",
        "crumbs",
        "oatmeal",

        "food",
        "legumes",
        

        };
        answerList = new int[] {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
            2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2
        };
        itemMap = new string[3] { "Recycle", "Not Dispose", "Compost" };
        levenArray = new int[itemList.Length];
        min1 = 0;
        min2 = 0;
        min3 = 0;
    }

    public void tryQuery()
    {
        Debug.Log(input.text);
        GiveQuery(input.text);
    }

    public void GiveQuery(string name)
    {
        if (itemList.Contains(name))
        {
            answer.text = itemMap[answerList[Array.IndexOf(itemList, name)]];
            queryPanel.SetActive(true);
        }
        else
        {
            for (int i = 0; i < itemList.Length; i++)
            {
                levenArray[i] = CalcLevenshteinDistance(name, itemList[i]);
            }

            min1 = 0;
            min2 = 0;
            min3 = 0;
            int currentMin1 = 10000;
            int currentMin2 = 10000;
            int currentMin3 = 10000;


            for (int i = 0; i < levenArray.Length; i++)
            {
                if (levenArray[i] < currentMin1)
                {
                    currentMin1 = levenArray[i];
                    min1 = i;
                }
            }

            levenArray[min1] = 10000;

            for (int i = 0; i < levenArray.Length; i++)
            {
                if (levenArray[i] < currentMin2)
                {
                    currentMin2 = levenArray[i];
                    min2 = i;
                }
            }

            levenArray[min2] = 10000;

            for (int i = 0; i < levenArray.Length; i++)
            {
                if (levenArray[i] < currentMin3)
                {
                    currentMin3 = levenArray[i];
                    min3 = i;
                }
            }

            dym1.GetComponentInChildren<Text>().text = itemList[min1];
            dym2.GetComponentInChildren<Text>().text = itemList[min2];
            dym3.GetComponentInChildren<Text>().text = itemList[min3];

            dymPanel.SetActive(true);

        }
    }

    public void dymButton1()
    {
        dymPanel.SetActive(false);
        GiveQuery(itemList[min1]);
    }

    public void dymButton2()
    {
        dymPanel.SetActive(false);
        GiveQuery(itemList[min2]);
    }

    public void dymButton3()
    {
        dymPanel.SetActive(false);
        GiveQuery(itemList[min3]);
    }

    public void backButton()
    {
        SceneManager.LoadScene(0);
    }

    public void closeDYM()
    {
        dymPanel.SetActive(false);
    }

    public void closeQuery()
    {
        queryPanel.SetActive(false);
    }

    private static int CalcLevenshteinDistance(string a, string b)
    {
        if (String.IsNullOrEmpty(a) && String.IsNullOrEmpty(b))
        {
            return 0;
        }
        if (String.IsNullOrEmpty(a))
        {
            return b.Length;
        }
        if (String.IsNullOrEmpty(b))
        {
            return a.Length;
        }
        int lengthA = a.Length;
        int lengthB = b.Length;
        var distances = new int[lengthA + 1, lengthB + 1];
        for (int i = 0; i <= lengthA; distances[i, 0] = i++) ;
        for (int j = 0; j <= lengthB; distances[0, j] = j++) ;

        for (int i = 1; i <= lengthA; i++)
            for (int j = 1; j <= lengthB; j++)
            {
                int cost = b[j - 1] == a[i - 1] ? 0 : 1;
                distances[i, j] = Math.Min
                    (
                    Math.Min(distances[i - 1, j] + 1, distances[i, j - 1] + 1),
                    distances[i - 1, j - 1] + cost
                    );
            }
        return distances[lengthA, lengthB];
    }
}
