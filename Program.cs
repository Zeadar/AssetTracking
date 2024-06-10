using AssetTracking;

Office sweden = new Office("Sweden", Currency.SEK);
Office usa = new Office("USA", Currency.USD);
Office germany = new Office("Germany", Currency.EUR);

Tracker tracker = new Tracker();

//Default list of assets
//P.S I made up the model names from my limited imagination
tracker.AddAsset(new Smartphone(new Price(200, Currency.USD), DateTime.Now.AddMonths(-36 + 4), "Motorola", "X3", usa));
tracker.AddAsset(new Smartphone(new Price(400, Currency.USD), DateTime.Now.AddMonths(-36 + 5), "Motorola", "X3", usa));
tracker.AddAsset(new Smartphone(new Price(400, Currency.USD), DateTime.Now.AddMonths(-36 + 10), "Motorola", "X2", usa));
tracker.AddAsset(new Smartphone(new Price(4500, Currency.SEK), DateTime.Now.AddMonths(-36 + 6), "Samsung", "Galaxy 10", sweden));
tracker.AddAsset(new Smartphone(new Price(4500, Currency.SEK), DateTime.Now.AddMonths(-36 + 7), "Samsung", "Galaxy 10", sweden));
tracker.AddAsset(new Smartphone(new Price(3000, Currency.SEK), DateTime.Now.AddMonths(-36 + 4), "Sony", "XPeria 7", sweden));
tracker.AddAsset(new Smartphone(new Price(3000, Currency.SEK), DateTime.Now.AddMonths(-36 + 5), "Sony", "XPeria 7", sweden));
tracker.AddAsset(new Smartphone(new Price(220, Currency.EUR), DateTime.Now.AddMonths(-36 + 12), "Siemens", "Brick", germany));

tracker.AddAsset(new Computer(new Price(100, Currency.USD), DateTime.Now.AddMonths(-38), "Dell", "Desktop 900", usa));
tracker.AddAsset(new Computer(new Price(100, Currency.USD), DateTime.Now.AddMonths(-37), "Dell", "Desktop 900", usa));
tracker.AddAsset(new Computer(new Price(300, Currency.USD), DateTime.Now.AddMonths(-36 + 1), "Lenovo", "X100", usa));
tracker.AddAsset(new Computer(new Price(300, Currency.USD), DateTime.Now.AddMonths(-36 + 4), "Lenovo", "X200", usa));
tracker.AddAsset(new Computer(new Price(500, Currency.USD), DateTime.Now.AddMonths(-36 + 9), "Lenovo", "X300", usa));
tracker.AddAsset(new Computer(new Price(1500, Currency.SEK), DateTime.Now.AddMonths(-36 + 7), "Dell", "Optiplex 100", sweden));
tracker.AddAsset(new Computer(new Price(1400, Currency.SEK), DateTime.Now.AddMonths(-36 + 8), "Dell", "Optiplex 200", sweden));
tracker.AddAsset(new Computer(new Price(1300, Currency.SEK), DateTime.Now.AddMonths(-36 + 9), "Dell", "Optiplex 300", sweden));
tracker.AddAsset(new Computer(new Price(1600, Currency.EUR), DateTime.Now.AddMonths(-36 + 14), "Asus", "ROG 600", germany));
tracker.AddAsset(new Computer(new Price(1200, Currency.EUR), DateTime.Now.AddMonths(-36 + 4), "Asus", "ROG 500", germany));
tracker.AddAsset(new Computer(new Price(1200, Currency.EUR), DateTime.Now.AddMonths(-36 + 3), "Asus", "ROG 500", germany));
tracker.AddAsset(new Computer(new Price(1300, Currency.EUR), DateTime.Now.AddMonths(-36 + 2), "Asus", "ROG 500", germany));
MainMenu();

void MainMenu(){
	Console.WriteLine("Enter corresponding letters highlighted with [_].");

	while (true){
	Console.WriteLine("[L]ist assets");
	Console.WriteLine("[A]dd asset");
	Console.WriteLine("[Q]uit");
		string input = ColorWriter.YellowPrompt("[L] [A] [Q]");
		switch(input){
		case "L":
			tracker.printAssets();
			break;
		case "A":
			QueryAsset();
			break;
		case "Q":
			Quit();
			break;
		default:
			ColorWriter.RedLine($"Unrecongnised input \"{input}\"");
			break;
		}
	}
}

void Quit(){
	Console.WriteLine("Are you sure? [Y]");
	switch(ColorWriter.YellowPrompt("[Y]")){
		case "Y":
			Environment.Exit(0);
			break;
		default:
			break;
	}
}

void QueryAsset(){
	while (true){
		Console.WriteLine("Add [C]omputer");
		Console.WriteLine("Add [S]martphone");
		Console.WriteLine("Go back [Q]");
		string input = ColorWriter.YellowPrompt("[C] [S] [Q]");

		if (input == "Q"){
			break; //Can't do this in switch case
		}
		
		switch (input){
			case "C":
				AddComputer();
				break;
			case "S":
				AddSmartphone();
				break;
			default:
				break;
		}
	}
}

//Storing asset type as class name is the worst idea I've ever had
//Would prefer to just have an AddAsset() function but now I 
//need to repeat for every class :(
void AddComputer(){
	try { //Capitalize can fail if string is empty and I am feeling extra lazy today
		string brand = Capitalize(ColorWriter.YellowPrompt("Brand name: string"));
		string model = Capitalize(ColorWriter.YellowPrompt("Model name: string"));
		Office office = queryOffice();
		Price price = queryPrice();
		DateTime time = queryTime();
		Computer pc = new Computer(price, time, brand, model, office);
		tracker.AddAsset(pc);
		ColorWriter.GreenLine("Added Computer");
		ColorWriter.GreenLine(pc.ToString());
	} catch (Exception ex){
		ColorWriter.RedLine(ex.Message);
	}
}

void AddSmartphone(){
	try {
		string brand = Capitalize(ColorWriter.YellowPrompt("Brand name: string"));
		string model = Capitalize(ColorWriter.YellowPrompt("Model name: string"));
		Office office = queryOffice();
		Price price = queryPrice();
		DateTime time = queryTime();
		Smartphone sp = new Smartphone(price, time, brand, model, office);
		tracker.AddAsset(sp);
		ColorWriter.GreenLine("Added Smartphone");
		ColorWriter.GreenLine(sp.ToString());
	} catch (Exception ex) {
		ColorWriter.RedLine(ex.Message);
	}
}

Price queryPrice(){
	Console.WriteLine("Enter purchase price currency");
	Console.WriteLine($"[1] {Currency.SEK}");
	Console.WriteLine($"[2] {Currency.USD}");
	Console.WriteLine($"[3] {Currency.EUR}");
	Currency? currency = null;

	while (true){
		string input = ColorWriter.YellowPrompt("[1][2][3]");

		try {
			int p = Convert.ToInt32(input);
			switch (p){
				case 1:
					currency = Currency.SEK;
					break;
				case 2:
					currency = Currency.USD;
					break;
				case 3:
					currency = Currency.EUR;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		} catch (Exception ex){
			ColorWriter.RedLine(ex.Message);
		}

		if (currency != null){
			break;
		}
	} 

	while (true){
		string input = ColorWriter.YellowPrompt($"Enter price ({currency.ToString()})");

		try {
			double p = Convert.ToDouble(input);
			return new Price(p, (Currency)currency);
		} catch (Exception ex){
			ColorWriter.RedLine(ex.Message);
		}
	}
}

DateTime queryTime(){
	Console.WriteLine("Enter time as format yyyy-Mm-dd");
	Console.WriteLine("Or enter \"NOW\" for current date");
	while (true){
		string input = ColorWriter.YellowPrompt("[yyyy-MM-dd] [NOW]");

		if (input == "NOW"){
			return DateTime.Now;
		}

		try {
			return Convert.ToDateTime(input);
		} catch (Exception ex){
			ColorWriter.RedLine(ex.Message);
		}
	}
}

Office queryOffice(){
	Console.WriteLine("Choose office");
	Console.WriteLine("[1] Sweden");
	Console.WriteLine("[2] USA");
	Console.WriteLine("[3] Germany");

	while (true){
		string input = ColorWriter.YellowPrompt("[1] [2] [3]");
		try {
			int p = Convert.ToInt32(input);

			switch(p){
				case 1:
					return sweden;
				case 2:
					return usa;
				case 3:
					return germany;
				default:
					throw new ArgumentOutOfRangeException();
			}
		} catch (Exception ex){
			ColorWriter.RedLine(ex.Message);
		}
	}
}

string Capitalize(string input){
	return $"{input.Substring(0, 1).ToUpper()}{input.Substring(1).ToLower()}";
}
