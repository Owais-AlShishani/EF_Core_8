//NorthwindDb db = new();
//db.Database.EnsureCreated();
//WriteLine($"Provider {db.Database.ProviderName}");

//WorkingWithEFCore.Program.ConfigureConsole();
//WorkingWithEFCore.Program.QueryingCategories();
//WorkingWithEFCore.Program.FilteredIncludes();
//WorkingWithEFCore.Program.FilteredIncludes();
//WorkingWithEFCore.Program.QueryingProducts();
//WorkingWithEFCore.Program.GettingOneProduct();
//WorkingWithEFCore.Program.QueryingWithLike();
//WorkingWithEFCore.Program.GetRandomProduct();
//WorkingWithEFCore.Program.GettingOneProduct();
//WorkingWithEFCore.Program.LazyLoadingWithNoTracking();

//---------------

//var resultAdd = WorkingWithEFCore.Program.AddProduct(categoryId: 6, productName: "Bob's Burgers", price: 250M, stock: 40);
//if (resultAdd.affected == 1)
//{
//    WriteLine($"Add product successful with ID: {resultAdd.productId}.");
//}
//WorkingWithEFCore.Program.ListProducts(productIdsToHighlight: new[] { resultAdd.productId });

//---------------

//var resultUpdate = WorkingWithEFCore.Program.IncreaseProductPrice(
// productNameStartsWith: "Bob", amount: 20M);
//if (resultUpdate.affected == 1)
//{
//    WriteLine($"Increase price success for ID: {resultUpdate.productId}.");
//}
//WorkingWithEFCore.Program.ListProducts(productIdsToHighlight: new[] { resultUpdate.productId });

//---------------

//WriteLine("About to delete all products whose name starts with Bob.");
//Write("Press Enter to continue or any other key to exit: ");
//if (ReadKey(intercept: true).Key == ConsoleKey.Enter)
//{
//    int deleted = WorkingWithEFCore.Program.DeleteProducts(productNameStartsWith: "Bob");
//    WriteLine($"{deleted} product(s) were deleted.");
//}
//else
//{
//    WriteLine("Delete was canceled.");
//}

//var resultUpdateBetter = WorkingWithEFCore.Program.IncreaseProductPricesBetter(
// productNameStartsWith: "Bob", amount: 20M);
//if (resultUpdateBetter.affected > 0)
//{
//    WriteLine("Increase product price successful.");
//}
//WorkingWithEFCore.Program.ListProducts(productIdsToHighlight: resultUpdateBetter.productIds);


//---------------


WriteLine("About to delete all products whose name starts with Bob.");
Write("Press Enter to continue or any other key to exit: ");
if (ReadKey(intercept: true).Key == ConsoleKey.Enter)
{
    int deleted = WorkingWithEFCore.Program.DeleteProductsBetter(productNameStartsWith: "Bob");
    WriteLine($"{deleted} product(s) were deleted.");
}
else
{
    WriteLine("Delete was canceled.");
}