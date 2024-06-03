namespace AssetTracking{
 	public enum Currency{
		SEK,
		USD,
		EUR,
		KGS,
		VND,
	}

	public class Converter{
		//Exchange rates of 2024-06-03.
		//Other currency to USD multiplyer.
		//This is not how currency exhange in the real world works because all currencies has
		//an exchange rate to other currencies without using dollars in between.

		//For the imaginary purpose of this project, the company stores all money in dollars
		//and exchanges them to other currencies when needed.
		static readonly Dictionary<Currency, double> exchangeRate = new Dictionary<Currency, double>() {
			{Currency.SEK, 0.0950043},
			{Currency.EUR, 1.08365},
			{Currency.KGS, 0.0114025},
			{Currency.VND, 25664.465},
			{Currency.USD, 1.0},
		};

		static public double Exchange(Currency fr, Currency to, double amount){
			return (amount * exchangeRate[fr]) / exchangeRate[to];
		}
		
	}
}
