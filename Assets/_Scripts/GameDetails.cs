using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDetails : MonoBehaviour
{
    string[] itemList;
    int[] answerList;
    int randomIndex;
    public Text displayText;
    public GameObject correctPanel;
    public GameObject incorrectPanel;

    // Start is called before the first frame update
    //0 - trash, 1 - recycle, 2 - compost
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

        "nut",
        "carrot",

        "milk",
        "napkin",
        "towel",
        "crumbs",
        "oatmeal",

        "food",
        "legumes",

        "tape",
        "laminated paper",
        "lightbulb",
        "styrofoam",
        "pizza boxes",
        "diaper",
        "hygiene products",
        "shampoo",
        "conditioner",
        "body soap",
        "rubber bands",
        "toothpaste",
        "toy",
        "hangers",

        "plastic wrap",
        "packing peanuts",
        "bubble wraps",
        "polystyrene",
        "wax",
        "foam egg cartons",
        "medical waste",
        "photograph",
        "mirror",
        "ceramics",
        "dental floss",
        "cotton swabs",
        "make up pad",
        "baby wipes",
        "plastic straws",
        "broken glass",
        "broken dishes",

        };
        answerList = new int[] {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
            2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1
        };
        randomIndex = Random.Range(0, itemList.Length);
        displayText.text = itemList[randomIndex];
    }

    public void updateDisplay()
    {
        randomIndex = Random.Range(0, itemList.Length);
        displayText.text = itemList[randomIndex];
    }

    private void checkAnswer(int selected)
    {
        if (selected == answerList[randomIndex])
        {
            correctPanel.SetActive(true);
        }
        else
        {
            incorrectPanel.SetActive(true);
        }
    }

    public void answerTrash()
    {
        checkAnswer(1);
    }

    public void answerRecycle()
    {
        checkAnswer(0);
    }

    public void answerCompost()
    {
        checkAnswer(2);
    }

    public void closeIncorrectPanel()
    {
        GameObject.Find("IncorrectPopup").SetActive(false);
    }

    public void closeCorrectPanel()
    {
        updateDisplay();
        GameObject.Find("CorrectPopup").SetActive(false);
    }

    public void backButton()
    {
        SceneManager.LoadScene(0);
    }
}
