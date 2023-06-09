﻿using Price_Calculator.Model;
using Price_Calculator.ValidationInputs;

namespace Price_Calculator.Utils
{
    public static class InputValidator
    {
        private readonly static string stringPattern = @"^[a-zA-Z\s]+$";
        private readonly static string pricePattern = @"^\d+(\.\d{1,2})?$";
        private readonly static string upcPattern = @"^\d+$";
        private readonly static string taxPattern = @"^\d+(\.\d{1,2})?$";
        private readonly static string discountPattern = @"^\d+(\.\d{1,2})?$";
        private readonly static string booleanPattern = @"^(True|False|true|false)$";

        public static Product InputValidation()
        {
            var name = StringInputValidation("Enter The Product Name");
            var price = PriceInputValidation();
            var upc = UpcInputValidation();
            var tax = DoubleInputs("Enter The Product Tax");
            var discount = DiscountInputValidation();
            var upcDiscount = UpcDiscountInputValidation();
            var upcValue = UpcValueInputValidation();
            var applyUpcDiscountsBeforeTax = BooleanInputValidation();
            var packagingCost = DoubleInputs("Enter The Product Packaging Cost");
            var transportCost = DoubleInputs("Enter The Product Transport Cost");
            var IsNormalDiscount = BooleanInputValidation();
            var cap = DoubleInputs("Enter The Product Cap");
            var currancyType = StringInputValidation("Enter The Currancy Type");

            var product = new Product(name, price, upc, tax, discount, upcValue
                , upcDiscount, applyUpcDiscountsBeforeTax, transportCost
                , packagingCost, IsNormalDiscount,cap,currancyType);

            return product;
        }
        private static string StringInputValidation(string message)
        {
            Console.WriteLine(message);

            var name = Console.ReadLine()?.Trim();
            var nameString = name.InputsValidatedUsingRegularExpression(stringPattern);

            return nameString;
        }
        private static int UpcInputValidation()
        {
            Console.WriteLine("Enter The Product Upc");

            var upcInput = Console.ReadLine();
            var upcString = upcInput.InputsValidatedUsingRegularExpression(upcPattern);

            return int.Parse(upcString);
        }
        private static decimal PriceInputValidation()
        {
            Console.WriteLine("Enter The Product Price");

            var priceInput = Console.ReadLine();
            var stringPrice = priceInput.InputsValidatedUsingRegularExpression(pricePattern);

            return Convert.ToDecimal(stringPrice);
        }
        private static double DoubleInputs(string message)
        {
            Console.WriteLine(message);

            var taxInput = Console.ReadLine();
            var taxDouble = taxInput.InputsValidatedUsingRegularExpression(taxPattern);

            return Convert.ToDouble(taxDouble);
        }
        private static double DiscountInputValidation()
        {
            Console.WriteLine("Enter The Product Discount");

            var discountInput = Console.ReadLine();
            var discountDouble = discountInput.InputsValidatedUsingRegularExpression(discountPattern);

            return Convert.ToDouble(discountDouble);
        }
        private static double UpcDiscountInputValidation()
        {
            Console.WriteLine("Enter The Product UPC Discount");

            var upcDiscountInput = Console.ReadLine();
            var discountDouble = upcDiscountInput.InputsValidatedUsingRegularExpression(discountPattern);

            return Convert.ToDouble(discountDouble);
        }
        private static int UpcValueInputValidation()
        {
            Console.WriteLine("Enter The Product UPC value");

            var upcValueInput = Console.ReadLine();
            var upcValueDouble = upcValueInput.InputsValidatedUsingRegularExpression(discountPattern);

            return int.Parse(upcValueDouble);
        }

        private static bool BooleanInputValidation()
        {
            Console.WriteLine("Enter The True if you like to Apply Discounts Before Tax or false to Apply Discounts After Tax ");

            var applyDiscountsBeforeTax = Console.ReadLine();
            var applyDiscountsBeforeTaxBool = applyDiscountsBeforeTax.InputsValidatedUsingRegularExpression(booleanPattern);

            return bool.Parse(applyDiscountsBeforeTaxBool);
        }
    }
}