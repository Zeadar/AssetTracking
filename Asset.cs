namespace AssetTracking{
	public abstract class Asset{
		protected Price price;
		protected DateTime datePurchased;

		public Price Price{
			get {
				return price;
			}
		}

		public string Model {get; set;}
		public string Brand {get; set;}

		public DateTime DatePurchased {
			get {
				return datePurchased;
			}
		}

		public Office Office {get; set;}

        public override string ToString() {
			string c = this.GetType().ToString().Split(".")[1].PadRight(25);
			string p = Price.ToString().PadRight(25);
			string l = string.Concat(Office.Currency.ToString(), " ", Price.getValue(Office.Currency).ToString("F2")).PadRight(25);
			string d = datePurchased.ToString("yyyy-MM-dd").PadRight(25);
			string b = Brand.PadRight(25);
			string m = Model.PadRight(25);
			string o = Office.Location.PadRight(25);
			return $"{o}{c}{b}{m}{p}{l}{d}";
        }

		public Asset(Price price, DateTime datePurchased, Office office){
			this.price = price;
			this.datePurchased = datePurchased;
			Office = office;
			Model = "Miscellaneous";
			Brand = "Miscellaneous";
		}
	}

	public class Computer : Asset {
		public Computer(Price price, DateTime datePurchased, string brand, string model, Office office) : base (price, datePurchased, office){
			Model = model;
			Brand = brand;
		}
	}

	public class Smartphone : Asset {
		public Smartphone(Price price, DateTime datePurchased, string brand, string model, Office office) : base (price, datePurchased, office){
			Model = model;
			Brand = brand;
		}
	}
}
