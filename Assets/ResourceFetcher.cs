using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public struct Description
{
    public string en;
    public string fr;
}

public struct Criteria
{
    public Description description;
    public int value;
};

public struct BackgroundSprites
{
    public Sprite level1;
    public Sprite level2;
    public Sprite level3;
    public Sprite level4;
    public Sprite level5;
};

public class ResourceFetcher : MonoBehaviour
{

    List<Criteria> criterias;
    List<string> firstNames;
    List<string> lastNames;
    public Sprite[] headshapes;
    public Sprite[] clothes;
    public Sprite[] mouths;
    public Sprite[] noses;
    public Sprite[] eyes;
    public Sprite[] eyebrows;
    public Sprite[] hairs;
    public Sprite evilEyes;
    public BackgroundSprites backgroundSprites;
    ResourcesSource resourcesSource = new ResourcesSource();

    // Start is called before the first frame update
    void Awake()
    {
        FetchFirstNames();
        FetchLastNames();
        FetchCriteria();
        FetchAvatars();
        FetchBackground();
    }

    public List<Criteria> GetCriterias()
    {
        return criterias;
    }

    public List<string> GetFirstNames()
    {
        return firstNames;
    }

    public List<string> GetLastNames()
    {
        return lastNames;
    }

    public BackgroundSprites GetBackgroundSprites()
    {
        return backgroundSprites;
    }

    private void FetchFirstNames()
    {
        firstNames = new List<string>();
        var source = resourcesSource.GetFirstNames();
        foreach (string line in source.Split('\n')) {
            var values = line.Split(',');
            if (values.Length > 0)
                firstNames.Add(values[0]);
        }
        Debug.Log("Loaded " + firstNames.Count + " first names");
    }

    private void FetchLastNames()
    {
        lastNames = new List<string>();
        var source = resourcesSource.GetLastNames();
        foreach (string line in source.Split('\n'))
        {
            var values = line.Split(',');
            if (values.Length > 0)
                lastNames.Add(values[0]);
        }
        Debug.Log("Loaded " + lastNames.Count + " last names");
    }

    private void FetchCriteria()
    {
        criterias = new List<Criteria>();
        var source = resourcesSource.GetCriteria();
        foreach (string line in source.Split('\n'))
        {
            var values = line.Split(',');
            if (values.Length > 2 && int.TryParse(values[0], out int numValue))
            {
                Criteria newCriteria;
                Description newDescription;
                newDescription.en = values[1];
                newDescription.fr = values[2];
                newCriteria.description = newDescription;
                newCriteria.value = numValue;
                criterias.Add(newCriteria);
            }
        }
        Debug.Log("Loaded " + criterias.Count + " criteria");
    }

    private void FetchAvatars()
    {
        headshapes = Resources.LoadAll<Sprite>("ProfilePictures/headshape");
        clothes = Resources.LoadAll<Sprite>("ProfilePictures/clothes");
        mouths = Resources.LoadAll<Sprite>("ProfilePictures/mouth");
        noses = Resources.LoadAll<Sprite>("ProfilePictures/nose");
        eyes = Resources.LoadAll<Sprite>("ProfilePictures/eyes");
        eyebrows = Resources.LoadAll<Sprite>("ProfilePictures/eyebrows");
        hairs = Resources.LoadAll<Sprite>("ProfilePictures/hair");
        evilEyes = Resources.Load<Sprite>("ProfilePictures/DemonFeatures/demoneyes");

        Debug.Log("Loaded " + headshapes.Length + " headshapes");
        Debug.Log("Loaded " + clothes.Length + " clothes");
        Debug.Log("Loaded " + mouths.Length + " mouths");
        Debug.Log("Loaded " + noses.Length + " noses");
        Debug.Log("Loaded " + eyes.Length + " eyes");
        Debug.Log("Loaded " + eyebrows.Length + " eyebrows");
        Debug.Log("Loaded " + hairs.Length + " hairs");
    }

    private void FetchBackground()
    {
        backgroundSprites.level1 = Resources.Load<Sprite>("Backgrounds/lv1");
        backgroundSprites.level2 = Resources.Load<Sprite>("Backgrounds/lv2");
        backgroundSprites.level3 = Resources.Load<Sprite>("Backgrounds/lv3");
        backgroundSprites.level4 = Resources.Load<Sprite>("Backgrounds/lv4");
        backgroundSprites.level5 = Resources.Load<Sprite>("Backgrounds/lv5");
        Debug.Log("Backgrounds loaded");
    }

    // Update is called once per frame
    void Update()
    {

    }
}


class ResourcesSource
{
    public string GetFirstNames()
    {
        return @"James
John
Robert
Michael
William
David
Richard
Joseph
Thomas
Charles
Christopher
Daniel
Matthew
Anthony
Donald
Mark
Paul
Steven
Andrew
Kenneth
Joshua
Kevin
Brian
George
Edward
Ronald
Timothy
Jason
Jeffrey
Ryan
Jacob
Gary
Nicholas
Eric
Jonathan
Stephen
Larry
Justin
Scott
Brandon
Benjamin
Samuel
Frank
Gregory
Raymond
Alexander
Patrick
Jack
Tyler
Jerry
Mary
Patricia
Jennifer
Linda
Elizabeth
Barbara
Susan
Jessica
Sarah
Karen
Nancy
Lisa
Margareth
Ashley
Sandra
 ";
    }

    public string GetLastNames()
    {
        return @"Smith
Johnson
Williams
Brown
Jones
Miller
Davis
Garcia
Rodriguez
Wilson
Martinez
Anderson
Taylor
Thomas
Hernandez
Moore
Martin
Jackson
Thompson
White
Lopez
Lee
Gonzalez
Harris
Clark
Lewis
Robinson
Walker
Perez
Murphy
Evans
Roberts
Wright
Edwards
Green
Petit
Fournier
Richard
O'Connor
O'Neill
";
    }

    public string GetCriteria()
    {
        return @"-1,Drowned a puppy,A noy� un chiot
-1,Punched a kid,A frapp� un enfant
-1,Stole a TV,A vol� une t�l�
-1,Broke a friend's car,A cass� la voiture de son ami
-1,Burned a baby,A brul� un b�b�
-1,Cheated on his lover,A tromp� son partenaire
-1,Downloaded a game illegally,A t�l�charg� ill�galement un jeu
-1,Didn't pay his taxes,N'a pas pay� ses taxes
-1,Didn't recycle,N'a pas recycl�
-1,Drank holy water,A bu de l'eau b�nite
0,Lost the lottery,A perdu la lotterie
0,Played the piano,Jouait du piano
0,Listen to the birds,�coutait les oiseaux
0,Talked in his sleep,Parlait dans son sommeil
0,Bought a dishwasher,A achet� un lave-vaisselle
0,Was afraid of spiders,Avait peur des araign�es
0,Was allergic to puppies,�tait allergique aux chiots
0,Went to a great concert,Est all� � un super concert
0,Ran a marathon,A couru un marathon
0,Hated country music,D�testait la musique country
1,Held the door,A tenu la porte
1,Washed the dishes,A fait la vaisselle
1,Bought a present for his cousin,A achet� un cadeau pour son cousin
1,Says thank you to the baker,Remerciait le boulanger
1,Went to the church,Allait � l'�glise
1,Cooked for his sick mother,Cuisinait pour sa m�re malade
1,Gave money to a child,A donn� de l'argent � un enfant
1,Was faithful to his lover,�tait fid�le � son partenaire
1,Saved a baby from a fire,A sauv� un b�b� d'un incendie
1,Discovered a vaccine,A d�couvert un vaccin
0,Had a turtle collection,Avait une collection de tortues
1,Was active in their local communities,�tait actif dans leurs communaut�s locales";
    }

}