using AssetTracking;

Console.WriteLine(Converter.Exchange(Currency.SEK, Currency.USD, 100));
Console.WriteLine(Converter.Exchange(Currency.USD, Currency.SEK, 1));
Console.WriteLine(Converter.Exchange(Currency.SEK, Currency.KGS, 10));
Console.WriteLine(Converter.Exchange(Currency.SEK, Currency.SEK, 10));

