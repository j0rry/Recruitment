class Program{

    static List<string> SelectedCrew = new List<string>();
    static Dictionary<string, int> nameDictionary = new Dictionary<string, int>();
    static List<string> crew = ["Sigma", "Ligma", "Wata", "Fortnite", "TEO", "Elis", "Jorry"];

    static int powerRandomRange = 100;

    static GameStates gameStates = GameStates.Running;

    public enum GameStates{
        Menu,
        Running
    }

    static void Main(){


        // while(gameStates == GameStates.Menu){
        //     string name;
        //     int noOfNames;
        //     do{
        //         name = Console.ReadLine() ?? string.Empty;
        //     }while(string.IsNullOrWhiteSpace(name));
        //     crew.Add(name);
        // }

        foreach(string name in crew) AddName(name);

        while(nameDictionary.Count > 0 && gameStates == GameStates.Running){
            Console.Clear();
            int choice;

            foreach(string name in SelectedCrew){
                System.Console.Write($"{name} ");
            }
            Console.WriteLine();

            for(int i = 1; i <= nameDictionary.Count; i++) {
                var key = nameDictionary.Keys.ElementAt(i - 1);
                Console.WriteLine($"{i}. {key} - {nameDictionary[key]} Power");
            }

            Console.WriteLine("Välj en person som du vill rekrytera.");

            do{
                Console.Write("Nummer: ");
            }while(!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > nameDictionary.Count);

            var selectedKey = nameDictionary.Keys.ElementAt(choice - 1);
            nameDictionary.Remove(selectedKey);

            SelectedCrew.Add(selectedKey);
        }
    
    }

    static void AddName(string name){
        nameDictionary.Add(name, Random.Shared.Next(powerRandomRange + 1));
    }
}