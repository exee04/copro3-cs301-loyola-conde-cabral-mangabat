using System.Collections;
using System.Data;
using System.Data.SqlClient;
public struct CharacterInfo
{
    public string Name;
    public string ServerLocation;
    public string ServerType;
    public string Difficulty;
    public string Class;
    public string Allegiance;
    public string Race;
    public string Gender;
    public string SkinColor;
    public string BodyType;
    public string HairStyle;
    public string HairColor;
    public string IrisColor;
    public string Accessory;
    public string BaseJob;
    public string Voice;
    public string CompanionName;
    public string Trait;
    public int HeightScale;
    public bool IsAwakened;
}
public class NormalCharacter : CharacterCreationClass
{

    public NormalCharacter(SqlConnection connect)
    {
        createCharacter(connect);
        callDatabase(connect);
    }
}
public class AwakenedCharacter : CharacterCreationClass
{
    public AwakenedCharacter(SqlConnection connect)
    {

        createCharacter(connect);
        AwakenCharacter();
        callDatabase(connect);
    }

    public SqlConnection Connect { get; }
}
public class Character
{
    private CharacterInfo characterInformation;

    public string CharName
    {
        get { return characterInformation.Name; }
        set { characterInformation.Name = value; }
    }

    public string CharServerLocation
    {
        get { return characterInformation.ServerLocation; }
        set { characterInformation.ServerLocation = value; }
    }

    public string CharServerType
    {
        get { return characterInformation.ServerType; }
        set { characterInformation.ServerType = value; }
    }

    public string CharDifficulty
    {
        get { return characterInformation.Difficulty; }
        set { characterInformation.Difficulty = value; }
    }

    public string CharGender
    {
        get { return characterInformation.Gender; }
        set { characterInformation.Gender = value; }
    }

    public string CharClass
    {
        get { return characterInformation.Class; }
        set { characterInformation.Class = value; }
    }

    public string CharAllegiance
    {
        get { return characterInformation.Allegiance; }
        set { characterInformation.Allegiance = value; }
    }

    public string CharRace
    {
        get { return characterInformation.Race; }
        set { characterInformation.Race = value; }
    }

    public string CharBodyType
    {
        get { return characterInformation.BodyType; }
        set { characterInformation.BodyType = value; }
    }

    public string CharSkinColor
    {
        get { return characterInformation.SkinColor; }
        set { characterInformation.SkinColor = value; }
    }

    public string CharHairStyle
    {
        get { return characterInformation.HairStyle; }
        set { characterInformation.HairStyle = value; }
    }

    public string CharHairColor
    {
        get { return characterInformation.HairColor; }
        set { characterInformation.HairColor = value; }
    }

    public string CharIrisColor
    {
        get { return characterInformation.IrisColor; }
        set { characterInformation.IrisColor = value; }
    }

    public string CharAccessory
    {
        get { return characterInformation.Accessory; }
        set { characterInformation.Accessory = value; }
    }

    public string CharTrait
    {
        get { return characterInformation.Trait; }
        set { characterInformation.Trait = value; }
    }

    public string CharBaseJob
    {
        get { return characterInformation.BaseJob; }
        set { characterInformation.BaseJob = value; }
    }

    public string CharVoice
    {
        get { return characterInformation.Voice; }
        set { characterInformation.Voice = value; }
    }

    public string CharCompanionName
    {
        get { return characterInformation.CompanionName; }
        set { characterInformation.CompanionName = value; }
    }

    public int CharHeightScale
    {
        get { return characterInformation.HeightScale; }
        set { characterInformation.HeightScale = value; }
    }

    public bool CharIsAwakened
    {
        get { return characterInformation.IsAwakened; }
        set { characterInformation.IsAwakened = value; }
    }
}
public abstract class InputMethods
{
    public virtual string getInput(string input)
    {
        return input;
    }

    public virtual string getInput(string input, string[] choices)
    {
        return input;
    }
    public abstract int getHeightInput();
}


public class CharacterCreationClass : InputMethods
{
    public static Character character = new Character();
    public string[] availableServerLocations = { "Asia", "North America", "Europe" };
    public string[] availableServerType = { "Normal", "Seasonal", "PVP" };
    public string[] availableDifficulties = { "Standard", "Hardcore", "Solo Self Found" };
    public string[] availableClasses =
        {"Warrior", "Fighter", "Archer", "Ranger",
        "Mage", "Witch", "Paladin", "Death Knight",
        "Priest", "Bard", "Necromancer", "Rogue"};
    public string[] availableAllegiances = { "Alliance", "Horde" };
    public string[] availableRaces = { "Human", "Undead", "Blood Elf", "Dwarf", "Orc", "Lizard", "Giant" };
    public string[] availableGenders = { "Male", "Female" };
    public string[] availableBodyTypes = { "Buff", "Skinny", "Cut" };
    public string[] availableHairStyle =
        { "Crew Cut", "Shaved Head", "Bald Head", "Long Hair",
        "Braid", "Curly", "Spiky", "Bun", "Wolf Cut", "Fade"};
    public string[] availableAccessories = { "Shades", "Earring", "Face Mask", "Gold Chain", "Cap" };
    public string[] availableTraits = { "Charismatic", "Greedy", "Brave", "Temper", "Paranoid", "Unstoppable" };
    public string[] availableBaseJobs =
        {"Engineering", "Leatherworking", "Mining", "Herbalism", "Tailoring", "Cooking",
        "Fishing", "Blacksmithing", "Alchemy", "Inscription", "Skinning"};
    public string[] avaialableVoices = { "High Pitch", "Medium Pitch", "Low Pitch" };
    public string[] colors = {"Red", "Blue", "Green", "Pink", "Brown",
            "Magenta", "Orange", "White", "Yellow", "Black",
            "Gray", "Purple", "Maroon", "Silver", "Cyan" };
    public void callDatabase(SqlConnection connect)
    {
        DatabaseCharacter db = new DatabaseCharacter(character.CharName, character.CharServerLocation, character.CharServerType, character.CharDifficulty, character.CharGender,
        character.CharClass, character.CharAllegiance, character.CharRace, character.CharBodyType, character.CharHeightScale, character.CharSkinColor, character.CharHairStyle,
        character.CharHairColor, character.CharIrisColor, character.CharAccessory, character.CharTrait, character.CharBaseJob, character.CharVoice, character.CharCompanionName,
        character.CharIsAwakened
        );
        db.showCharacterInfo();
        db.AddToDatabase(connect);
    }
    public void AwakenCharacter()
    {
        character.CharIsAwakened = true;
    }
    static bool ContainsIgnoreCase(string[] choices, string input)
    {
        return Array.Exists(choices, choice => choice.Equals(input, StringComparison.OrdinalIgnoreCase));
    }
    static int IndexOfIgnoreCase(string[] choices, string input)
    {
        return Array.FindIndex(choices, choice => choice.Equals(input, StringComparison.OrdinalIgnoreCase));
    }
    public override string getInput(string infoName, string[] choices)
    {
        if (infoName.EndsWith("y"))
        {
            Console.Write($"----Available {infoName.Substring(0, infoName.Length - 1) + "ies"}----- \n");
        }
        else if (infoName.EndsWith("s"))
        {
            Console.Write($"----Available {infoName}es----- \n");
        }
        else
        {
            Console.Write($"----Available {infoName}s----- \n");
        }
        int i = 1;
        foreach (string choice in choices)
        {
            Console.WriteLine(i + ". " + choice);
            i++;
        }
        Console.WriteLine("----------------------------------");
        string input;
        string output;
        while (true)
        {
            Console.Write($"Enter {infoName} or the number: ");
            input = Console.ReadLine();

            if (int.TryParse(input, out int numericInput))
            {
                if (numericInput >= 1 && numericInput <= choices.Length)
                {
                    output = choices[numericInput - 1];
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
            else if (ContainsIgnoreCase(choices, input))
            {
                output = choices[IndexOfIgnoreCase(choices, input)];
                break;
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }
        return output;
    }

    public override string getInput(string infoName)
    {
        string userInput;
        while (true)
        {
            Console.Write($"Enter {infoName}: ");
            userInput = Console.ReadLine();
            if (userInput.Length == 0)
            {
                Console.WriteLine("Cannot be empty");
                continue;
            }
            else if (userInput.Length > 10)
            {
                Console.WriteLine("Input cannot exceed 10 characters");
                continue;
            }
            break;
        }
        return userInput;
    }
    public override int getHeightInput()
    {
        while (true)
        {
            try
            {
                Console.Write("Enter Height Scale (Only enter a number between 40 to 130): ");
                int number = int.Parse(Console.ReadLine());
                if (number >= 40 && number <= 130)
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Invalid Value");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Cannot be blank");
            }

        }
    }
    public string uniqueCharName(SqlConnection db)
    {
        string input;
        db.Open();
        while (true)
        {
            input = getInput("Character Name");
            try
            {
                string query = "SELECT COUNT(*) FROM [dbo].[Players] WHERE [Character Name] = @Username";
                using (SqlCommand command = new SqlCommand(query, db))
                {
                    command.Parameters.AddWithValue("@Username", input);

                    int count = (int)command.ExecuteScalar();
                    db.Close();
                    if (count == 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Username is taken");
                    }
                }
            }
            catch (Exception e)
            {

                return input;
            }

        }
        db.Close();
        return input;
    }
    public void createCharacter(SqlConnection connect)
    {
        character.CharName = uniqueCharName(connect);
        character.CharServerLocation = getInput("Server Location", availableServerLocations);
        character.CharServerType = getInput("Server Type", availableServerType);
        character.CharDifficulty = getInput("Difficulty", availableDifficulties);
        character.CharGender = getInput("Gender", availableGenders);
        character.CharClass = getInput("Class", availableClasses);
        character.CharAllegiance = getInput("Allegiance", availableAllegiances);
        character.CharRace = getInput("Race", availableRaces);
        character.CharBodyType = getInput("Body Type", availableBodyTypes);
        character.CharHeightScale = getHeightInput();
        character.CharSkinColor = getInput("Skin Color", colors);
        character.CharHairStyle = getInput("Hairstyle", availableHairStyle);
        character.CharHairColor = getInput("Hair Color", colors);
        character.CharIrisColor = getInput("Iris Color", colors);
        character.CharAccessory = getInput("Accessory", availableAccessories);
        character.CharTrait = getInput("Trait", availableTraits);
        character.CharBaseJob = getInput("Base Job", availableBaseJobs);
        character.CharVoice = getInput("Voice", avaialableVoices);
        character.CharCompanionName = getInput("Companion's name");
    }

}
public interface DatabaseFunctions
{
    public void showCharacterInfo();
    public void AddToDatabase(SqlConnection connect);


}
public class DatabaseCharacter : DatabaseFunctions
{

    private string charName;
    private string charServerLocation;
    private string charServerType;
    private string charDifficulty;
    private string charGender;
    private string charClass;
    private string charAllegiance;
    private string charRace;
    private string charBodyType;
    private string charSkinColor;
    private string charHairStyle;
    private string charHairColor;
    private string charIrisColor;
    private string charAccessory;
    private string charTrait;
    private string charBaseJob;
    private string charVoice;
    private string charCompanionName;
    private int charHeightScale;
    private bool isAwakened;
    public DatabaseCharacter(string charName, string charServerLocation, string charServerType, string charDifficulty,
        string charGender, string charClass, string charAllegiance, string charRace, string charBodyType, int charHeightScale,
        string charSkinColor, string charHairStyle, string charHairColor, string charIrisColor, string charAccessory,
        string charTrait, string charBaseJob, string charVoice, string charCompanionName, bool isAwakened)
    {
        this.charName = charName;
        this.charServerLocation = charServerLocation;
        this.charServerType = charServerType;
        this.charDifficulty = charDifficulty;
        this.charGender = charGender;
        this.charClass = charClass;
        this.charAllegiance = charAllegiance;
        this.charRace = charRace;
        this.charBodyType = charBodyType;
        this.charHeightScale = charHeightScale;
        this.charSkinColor = charSkinColor;
        this.charHairStyle = charHairStyle;
        this.charHairColor = charHairColor;
        this.charIrisColor = charIrisColor;
        this.charAccessory = charAccessory;
        this.charTrait = charTrait;
        this.charBaseJob = charBaseJob;
        this.charVoice = charVoice;
        this.charCompanionName = charCompanionName;
        this.isAwakened = isAwakened;
        Console.WriteLine("Characted Added!");
    }

    public void showCharacterInfo()
    {
        Console.WriteLine($"Character name: {charName}");
        Console.WriteLine($"Server Location: {charServerLocation}");
        Console.WriteLine($"Server Type: {charServerType}");
        Console.WriteLine($"Difficulty: {charDifficulty}");
        Console.WriteLine($"Gender: {charGender}");
        Console.WriteLine($"Class: {charClass}");
        Console.WriteLine($"Allegiance: {charAllegiance}");
        Console.WriteLine($"Race: {charRace}");
        Console.WriteLine($"Body Type: {charBodyType}");
        Console.WriteLine($"Height Scale: {charHeightScale}");
        Console.WriteLine($"Skin Color: {charSkinColor}");
        Console.WriteLine($"Hair Style: {charHairStyle}");
        Console.WriteLine($"Hair Color: {charHairColor}");
        Console.WriteLine($"Iris Color: {charIrisColor}");
        Console.WriteLine($"Accessory: {charAccessory}");
        Console.WriteLine($"Trait: {charTrait}");
        Console.WriteLine($"Base Job: {charBaseJob}");
        Console.WriteLine($"Voice: {charVoice}");
        Console.WriteLine($"Companion's Name: {charCompanionName}");
        Console.WriteLine($"Is Awakened: {isAwakened}");
    }

    public void AddToDatabase(SqlConnection connect)
    {
        try
        {
            connect.Open();

            Console.WriteLine("Success");

            string sqlINSERT = "INSERT INTO [dbo].[Players] ([Character Name], [Server Location], [Server Type], [Difficulty], [Gender], [Class], [Allegiance], [Race], [Body Type], [Height Scale], [Skin Color], [Hair Style], [Hair Color], [Iris Color], [Accessory], [Trait], [Base Job], [Voice], [Companion Name], [Is Awakened]) VALUES (@CharacterName, @ServerLocation, @ServerType, @Difficulty, @Gender, @Class, @Allegiance, @Race, @BodyType, @HeightScale, @SkinColor, @HairStyle, @HairColor, @IrisColor, @Accessory, @Trait, @BaseJob, @Voice, @CompanionName, @IsAwakened)";

            SqlCommand command = new SqlCommand(sqlINSERT, connect);
            command.Prepare();

            command.Parameters.Add("@CharacterName", SqlDbType.VarChar, 50).Value = charName;
            command.Parameters.Add("@ServerLocation", SqlDbType.VarChar, 50).Value = charServerLocation;
            command.Parameters.Add("@ServerType", SqlDbType.VarChar, 50).Value = charServerType;
            command.Parameters.Add("@Difficulty", SqlDbType.VarChar, 50).Value = charDifficulty;
            command.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = charGender;
            command.Parameters.Add("@Class", SqlDbType.VarChar, 50).Value = charClass;
            command.Parameters.Add("@Allegiance", SqlDbType.VarChar, 50).Value = charAllegiance;
            command.Parameters.Add("@Race", SqlDbType.VarChar, 50).Value = charRace;
            command.Parameters.Add("@BodyType", SqlDbType.VarChar, 50).Value = charBodyType;
            command.Parameters.Add("@HeightScale", SqlDbType.Int).Value = charHeightScale;
            command.Parameters.Add("@SkinColor", SqlDbType.VarChar, 50).Value = charSkinColor;
            command.Parameters.Add("@HairStyle", SqlDbType.VarChar, 50).Value = charHairStyle;
            command.Parameters.Add("@HairColor", SqlDbType.VarChar, 50).Value = charHairColor;
            command.Parameters.Add("@IrisColor", SqlDbType.VarChar, 50).Value = charIrisColor;
            command.Parameters.Add("@Accessory", SqlDbType.VarChar, 50).Value = charAccessory;
            command.Parameters.Add("@Trait", SqlDbType.VarChar, 50).Value = charTrait;
            command.Parameters.Add("@BaseJob", SqlDbType.VarChar, 50).Value = charBaseJob;
            command.Parameters.Add("@Voice", SqlDbType.VarChar, 50).Value = charVoice;
            command.Parameters.Add("@CompanionName", SqlDbType.VarChar, 50).Value = charCompanionName;
            command.Parameters.Add("@IsAwakened", SqlDbType.Bit).Value = isAwakened;

            command.ExecuteNonQuery();
            Console.WriteLine("Character added to database!");
            connect.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
public class Database
{
    static SqlConnection connection;
    public Database()
    {
        try
        {
            string dbConnection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GAMEDB;Integrated Security=True";
            connection = new SqlConnection(dbConnection);
        }
        catch (Exception e)
        {
            Console.WriteLine("Unable to connect to database");
            Console.WriteLine("Error: " + e.Message);
        }
    }
    public SqlConnection Connection()
    {
        return connection;
    }
    public static void DisplayCharacterNames()
    {
        while (true)
        {
            connection.Open();
            ArrayList characters = new ArrayList();
            string sql = "SELECT [Character Name] FROM [dbo].[Players]";
            using (SqlCommand command = new SqlCommand(sql, connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                Console.WriteLine("Characters: ");
                int i = 1;
                while (reader.Read())
                {
                    Console.Write(i++ + ".) ");
                    characters.Add(reader["Character Name"].ToString());
                    Console.WriteLine(reader["Character Name"]);
                }
                if (characters.Count == 0)
                {
                    Console.WriteLine("No character added yet");
                    break;
                }
            }
            int decision;
            string choice;
            while (true)
            {
                try
                {
                    decision = int.Parse(Console.ReadLine());
                    choice = characters[decision - 1].ToString();
                    Console.WriteLine("You have selected: " + choice);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid choice");
                }
            }
            while (true)
            {
                Console.WriteLine("Select a character by entering a number");
                try
                {
                    Console.WriteLine("1. Show character info");
                    Console.WriteLine("2. Delete character");
                    Console.WriteLine("3. Return");
                    decision = int.Parse(Console.ReadLine());
                    if (decision == 1)
                    {
                        DisplayCharacterData(choice);

                    }
                    else if (decision == 2)
                    {
                        DeleteCharacter(choice);
                        break;
                    }
                    else if (decision == 3)
                    {
                        Console.WriteLine("Returning...");
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Input");
                }
            }
            connection.Close();
            break;
        }
    }

    public static void DisplayCharacterData(string charName)
    {
        string sql = "SELECT * FROM [dbo].[Players] WHERE [Character Name] = @CharName";
        using (SqlCommand command = new SqlCommand(sql, connection))
        {
            command.Parameters.AddWithValue("@CharName", charName);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine("\n------Character Data------");
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.WriteLine($"{reader.GetName(i)}: {reader[i]}");
                    }
                    Console.WriteLine("\n--------------------------");
                }
                else
                {
                    Console.WriteLine("Character not found.");
                }
            }
        }
    }
    static void DeleteCharacter(string charName)
    {
        string sql = "DELETE FROM [dbo].[Players] WHERE [Character Name] = @CharName";
        using (SqlCommand command = new SqlCommand(sql, connection))
        {
            command.Parameters.AddWithValue("@CharName", charName);
            string confirmation;
            do
            {
                Console.Write("Are you sure you want to delete this character? (y/n): ");
                confirmation = Console.ReadLine().ToLower();

                if (confirmation != "y" && confirmation != "n")
                {
                    Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                }
            } while (confirmation != "y" && confirmation != "n");

            if (confirmation == "y")
            {
                try
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Character deleted successfully.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error deleting character: " + e.Message);
                }
            }
            else
            {
                Console.WriteLine("Character deletion canceled.");
            }
        }
    }
}
public class MainClass
{
    public static void Main(string[] args)
    {
        Database database = new Database();
        while (true)
        {
            string input;
            Console.WriteLine("MOMOROPOG QUEST");
            Console.WriteLine("1. New Game\n2. New Game+\n3. Load Characters\nType anything else to exit");
            input = Console.ReadLine();
            if (input == "1")
            {
                CharacterCreationClass newChar = new NormalCharacter(database.Connection());
            }
            else if (input == "2")
            {
                CharacterCreationClass newChar = new AwakenedCharacter(database.Connection());
            }
            else if (input == "3")
            {
                Database.DisplayCharacterNames();
            }
            else
            {
                Console.WriteLine("Exiting...");
                break;
            }
        }
    }
}
