class Program
{
	static void Main(string[] args)
	{
		// Pocetno i krajnje stanje parkinga
		int[]? startState = null;
		int[]? endState = null;


		// Petlja za unos validnih pocetnih i krajnjih stanja
		while (startState == null || endState == null || startState.Length != endState.Length)
		{
			// Unos pocetnog stanja parkinga
			Console.WriteLine("Unesite pocetne pozicije automobila u parking prostoru razdvojene razmakom (e.g., '2 0 1 3'):");
			string? startStateInput = Console.ReadLine();
			startState = !string.IsNullOrEmpty(startStateInput) ? startStateInput.Split().Select(int.Parse).ToArray() : null;

			// Unos krajnjeg stanja parkinga
			Console.WriteLine("Unesite krajnje pozicije automobila u parking prostoru razdvojene razmakom (e.g., '3 1 0 2'):");
			string? endStateInput = Console.ReadLine();
			endState = !string.IsNullOrEmpty(endStateInput) ? endStateInput.Split().Select(int.Parse).ToArray() : null;


			// Provjera unosa
			if (startState == null || endState == null || startState.Length != endState.Length)
			Console.WriteLine("Pogresan unos. Pokusajte ponovo. \n");
		}

		// Rjesavanje problema parkiranja
		var result = SolveParkingProblem(startState, endState);

		// Ispis rezultata
		Console.WriteLine("\nRezultat:");
		if (result.Item1 == -1)
			Console.WriteLine("\nNema resenja.");
		else
			Console.WriteLine("\nBroj koraka:	" + result.Item1);

		// Ispis stanja za svaki korak
		for (int i = 1; i < result.Item2?.Count; i++)
		{
			Console.WriteLine("Stanje " + i + ": " + string.Join(" ", result.Item2[i]));
		}

		Console.ReadLine();
	}

	static (int, List<int[]>?) SolveParkingProblem(int[] startState, int[] endState)
	{
		int n = startState.Length; // Broj pozicija u parking prostoru
		string target = string.Join(",", endState); // Krajnje stanje parkinga kao string

		// Postavke BFS (Breadth-First Search) algoritma
		var queue = new Queue<(int[], int)>();  // Red za cuvanje stanja i broja koraka
		var visited = new Dictionary<string, (int, List<int[]>)>();  // Rjecnik za cuvanje posjecenih stanja

		// Inicijalno stanje
		queue.Enqueue((startState, 0));
		visited[string.Join(",", startState)] = (0, new List<int[]>());

		// BFS algoritam
		// Petlja se izvrsava dok ima elemenata u redu
		while (queue.Count > 0) 
		{	
			var (current, steps) = queue.Dequeue(); // Trenutno stanje i broj koraka
			string currentState = string.Join(",", current); // Trenutno stanje parkinga kao string

			// Provjera da li je trenutno stanje jednako krajnjem stanju
			if (currentState == target)
			{
				var path = new List<int[]>(visited[currentState].Item2) { current };
				return (steps, path);
			}

			// Indeks prazne pozicije
			int emptyIndex = Array.IndexOf(current, 0);

			// Pomjeranje automobila na slobodnu poziciju
			for (int i = 0; i < n; i++)
			{
				if (i != emptyIndex) // Provjera da li je pozicija prazna
				{
					var newState = (int[])current.Clone();
					newState[emptyIndex] = newState[i];
					newState[i] = 0;
					string newStateString = string.Join(",", newState);

					if (!visited.ContainsKey(newStateString)) // Provjera da li je stanje posjeceno
					{
						var newPath = new List<int[]>(visited[currentState].Item2) { current };
						visited[newStateString] = (steps + 1, newPath);
						queue.Enqueue((newState, steps + 1));
					}
				}
			}
		}

		// Nije pronađeno rješenje
		return (-1, null); 
	}
}