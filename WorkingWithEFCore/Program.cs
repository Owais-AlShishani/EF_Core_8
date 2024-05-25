using WorkingWithEFCore;

NorthwindDb db=new();
db.Database.EnsureCreated();
WriteLine($"Provider {db.Database.ProviderName}");