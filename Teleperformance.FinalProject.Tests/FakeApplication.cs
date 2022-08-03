using Microsoft.AspNetCore.Mvc.Testing;
using FinalProject.API.TestingNeeds;

namespace Teleperformance.FinalProject.Tests
{
    public class FakeApplication : WebApplicationFactory<Program>
    {
        public FakeApplication()
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Test");
        }
    }

}