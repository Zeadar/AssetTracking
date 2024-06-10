namespace AssetTracking{
	public class Office {
		public string Location {get; set;}
		public Currency Currency {get; set;}

		public Office(string location, Currency currency){
			Location = location;
			Currency = currency;
		}
	}
}
