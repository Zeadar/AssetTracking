namespace AssetTracking{
	public class Tracker{
		List<Asset> assets = new List<Asset>();

		public void AddAsset(Asset asset){
			assets.Add(asset);
		}

		public void printAssets(){
			var sortedAssets =
			assets.OrderBy(a => a.Office.Location)
			.ThenBy(a => a.GetType().ToString())
			.ThenByDescending(a => a.DatePurchased)
			.ToList();

			Console.ResetColor();
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.DarkBlue;
			Console.WriteLine("Office".PadRight(25) + "Asset".PadRight(25) + "Brand".PadRight(25)
				 + "Model".PadRight(25) + "Price (USD)".PadRight(25)
				 + "Price (Local)".PadRight(25) + "Purchase Date".PadRight(25));
			Console.ResetColor();
			//Console.WriteLine(); //This 
			foreach (Asset asset in sortedAssets){
				DateTime expiryDate = asset.DatePurchased.AddYears(3);
				DateTime redDate = asset.DatePurchased.AddYears(2).AddMonths(9);
				DateTime yellowDate = asset.DatePurchased.AddYears(2).AddMonths(6);
				if (expiryDate < DateTime.Now){
					//Expired
					ColorWriter.MatrixLine(asset.ToString(), ConsoleColor.Blue);
				} else if ( redDate < DateTime.Now){
					//Expires in 3 months
					ColorWriter.MatrixLine(asset.ToString(), ConsoleColor.Red);
				} else if ( yellowDate < DateTime.Now ){
					//Expires in 6 months
					ColorWriter.MatrixLine(asset.ToString(), ConsoleColor.Yellow);
				} else {
					//Not close to expiry date
					ColorWriter.MatrixLine(asset.ToString());
				}
			}
		}
	}
}
