namespace AssetTracking{
	public class Asset{
		double dollar = 0;

		public double getInCurrency(Currency currency){
			return Converter.Exchange(Currency.USD, currency, dollar);
		}

		public Asset(double dollar){
			this.dollar = dollar;
		}
	}
}
