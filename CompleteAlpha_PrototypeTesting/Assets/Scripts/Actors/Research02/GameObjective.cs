using UnityEngine;

[CreateAssetMenu(menuName = "Presset/GameObjective")]
public class GameObjective : ScriptableObject
{
    #region:values
    [Tooltip("A game objective")]
    [SerializeField]
    private GameObject objective01;

    public GameObject Objective01
    {
        get
        {
            return objective01;
        }
    }

    [Tooltip("A game objective")]
    [SerializeField]
    private GameObject objective02;

    public GameObject Objective02
    {
        get
        {
            return objective02;
        }
    }

    [Tooltip("A game objective")]
    [SerializeField]
    private GameObject objective03;

    public GameObject Objective03
    {
        get
        {
            return objective03;
        }
    }

    [Tooltip("A game objective")]
    [SerializeField]
    private GameObject objective04;

    public GameObject Objective04
    {
        get
        {
            return objective04;
        }
    }

    [Tooltip("A game objective")]
    [SerializeField]
    private GameObject objective05;

    public GameObject Objective05
    {
        get
        {
            return objective05;
        }
    }

    [Tooltip("A game objective")]
    [SerializeField]
    private GameObject objective06;

    public GameObject Objective06
    {
        get
        {
            return objective06;
        }
    }

    [Tooltip("A game objective")]
    [SerializeField]
    private GameObject objective07;

    public GameObject Objective07
    {
        get
        {
            return objective07;
        }
    }

    [Tooltip("A game objective")]
    [SerializeField]
    private GameObject objective08;

    public GameObject Objective08
    {
        get
        {
            return objective08;
        }
    }

    [Tooltip("A game objective")]
    [SerializeField]
    private GameObject objective09;

    public GameObject Objective09
    {
        get
        {
            return objective09;
        }
    }

    [Tooltip("A game objective")]
    [SerializeField]
    private GameObject objective10;

    public GameObject Objective10
    {
        get
        {
            return objective10;
        }
    }

    private GameObject[] compiledObjectives;

    public GameObject[] CompiledObjectives
    {
        get { return compiledObjectives; }
        set { compiledObjectives = value; }
    }

    private bool[] completedObjectives;

    public bool[] CompletedObjectives
    {
        get { return completedObjectives; }
        set { completedObjectives = value; }
    }

    #endregion

    #region:funtionalities
    private void Start()
    {
        compiledObjectives = new GameObject[] { objective01, objective02, objective03, objective04, objective05,
            objective06, objective07, objective08, objective09, objective10 };
        completedObjectives = new bool[completedObjectives.Length];
        for (int i = 0; i < compiledObjectives.Length; i++)
        {
            if (compiledObjectives[i] != null)
            {
                completedObjectives[i] = true;
            }
            else
            {
                completedObjectives[i] = false;
            }
        }
    }
    #endregion
}
