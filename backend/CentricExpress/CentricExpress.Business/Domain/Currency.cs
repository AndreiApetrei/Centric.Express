using System;

namespace CentricExpress.Business.Domain
{
    public enum Currency
    {
        Nothing,
        EUR,
        USD,
        RON
    }

    public class CurrencyParser
    {
        public static Currency TryParse(string currency)
        {
            Enum.TryParse(typeof(Domain.Currency), currency, out object parsedCurrency);

            return parsedCurrency == null ? Currency.Nothing : (Domain.Currency)parsedCurrency;
        }
    }
}