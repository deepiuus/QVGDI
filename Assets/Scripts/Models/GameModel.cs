using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[CreateAssetMenu(menuName = "Trivia/Create Game Model")]

public class GameModel : ScriptableObject
{
    public List<CategoryModel> categories;
}
