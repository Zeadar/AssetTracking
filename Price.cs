namespace AssetTracking{
	public class Price{
		double dollars;

		public Price(double price, Currency currency){
			dollars = Converter.Exchange(currency, Currency.USD, price);
		}

		public double getValue(Currency currency){
			return Converter.Exchange(Currency.USD, currency, dollars);
		}

        public override string ToString(){
            return dollars.ToString("F2");
        }
	}
}
