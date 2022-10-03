﻿
using Xunit;

namespace Tests
{
    [CollectionDefinition("InMemoryDbContext")]
    public class InMemoryDbContextFixtureCollection : ICollectionFixture<AdaptedWebApplicationFactory<backend.Startup>>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
